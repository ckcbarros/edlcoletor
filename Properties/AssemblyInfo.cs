using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Resources;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("EDL")]
[assembly: AssemblyDescription("EDL - Entrada Direta em Loja")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Drogaria Araujo")]
[assembly: AssemblyProduct("EDL - Entrada Direta em Loja")]
[assembly: AssemblyCopyright("Drogaria Araujo")]
[assembly: AssemblyTrademark("2016")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("7755dc51-1899-449a-a706-873e40b8ce7e")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
[assembly: AssemblyVersion("1.0.0.17")]

// Below attribute is to suppress FxCop warning "CA2232 : Microsoft.Usage : Add STAThreadAttribute to assembly"
// as Device app does not support STA thread.
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2232:MarkWindowsFormsEntryPointsWithStaThread")]
[assembly: NeutralResourcesLanguageAttribute("pt-BR")]
