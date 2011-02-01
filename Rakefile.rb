require 'albacore'
require 'rake/clean'

ROOT_NAMESPACE = "CoolCode"
RESULTS_DIR = "Results"
PRODUCT = ROOT_NAMESPACE
COPYRIGHT = 'Copyright 2011 Jarrod Peace';
COMMON_ASSEMBLY_INFO = 'Code/Source/CommonAssemblyInfo.cs';
CLR_VERSION = "v4.0"
COMPILE_TARGET = "Debug"
build_number = ""
props = { :build => "Build", :documentation => "Documentation" }

desc "Builds and packages the product"
task :all => [:default]

desc "Compiles, runs tests and packages"
task :default => [:compile, :test]

desc "Prepares the working directory for a new build"
CLEAN.include("#{props[:build]}/*")
CLEAN.include("#{RESULTS_DIR}/*")

desc "Update the version information for the build"
assemblyinfo :version do |asm|
  `git fetch`
  begin
	gittag = `git describe --long`.chomp 	# looks something like v0.1.0-63-g92228f4
	versionpart = /v?(\d+\.\d+\.\d+)/.match(gittag)
    gitnumberpart = /-(\d+)-/.match(gittag)
    gitnumber = gitnumberpart.nil? ? '0' : gitnumberpart[1]
    commit = `git log -1 --pretty=format:%H`
  rescue
    commit = "git unavailable"
    gitnumber = "0"
  end
  
  asm_version = "#{versionpart}.0"
  build_number = "#{versionpart}.#{gitnumber}"
  
  tc_build_number = ENV["BUILD_NUMBER"]
  puts "##teamcity[buildNumber '#{build_number}-#{tc_build_number}']" unless tc_build_number.nil?
  
  asm.trademark = commit
  asm.product_name = "#{PRODUCT} #{gittag}"
  asm.description = build_number
  asm.version = asm_version
  asm.file_version = build_number
  asm.custom_attributes :AssemblyInformationalVersion => asm_version
  asm.copyright = COPYRIGHT
  asm.output_file = COMMON_ASSEMBLY_INFO
end

desc "Compiles the app"
msbuild :compile => [:clean, :version] do |msb|
  msb.command = "C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\\MSBuild.exe"
  msb.properties :configuration => COMPILE_TARGET
  msb.targets :Clean, :Build
  msb.solution = "Code/Source/#{ROOT_NAMESPACE}.sln"
end

desc "Runs all tests"
task :test => [:unit_test]

desc "Runs all unit tests"
nunit :unit_test do |nunit|
	FileUtils.rm_r RESULTS_DIR, :force => true
	nunit.command = "Tools/NUnit/nunit-console.exe"
	nunit.assemblies File.expand_path("Code/Source/#{ROOT_NAMESPACE}.Tests/bin/#{COMPILE_TARGET}/#{ROOT_NAMESPACE}.Tests.dll")
	nunit.parameters "/xml:#{RESULTS_DIR}/nunit_results.xml"
end