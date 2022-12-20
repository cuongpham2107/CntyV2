using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ApplicationBuilder;
using DevExpress.ExpressApp.Blazor;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Security.ClientServer;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Xpo;
using CNTYv2.Blazor.Server.Services;
using CNTYv2.Blazor.Server.Templates;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Blazor.Templates;

namespace CNTYv2.Blazor.Server;

public class CNTYv2BlazorApplication : BlazorApplication {
    protected override IFrameTemplate CreateDefaultTemplate(TemplateContext context)
    {

        if (context == TemplateContext.LogonWindow)
        {
            return new CustomLogonWindowTemplate();
        }
        if(context == TemplateContext.NestedFrame)
        {
            return new CustomNestedFrameTemplate();
        }
        if(context == TemplateContext.ApplicationWindow)
        {
            return new CustomApplicationWindowTemplate();
        }
        return base.CreateDefaultTemplate(context);

        
    }
    public CNTYv2BlazorApplication() {

        LinkNewObjectToParentImmediately = true;
        ApplicationName = "CNTYv2";
        CheckCompatibilityType = DevExpress.ExpressApp.CheckCompatibilityType.DatabaseSchema;
        DatabaseVersionMismatch += CNTYv2BlazorApplication_DatabaseVersionMismatch;

        CustomizeTemplate += (s, e) => {
            if (e.Template is IPopupWindowTemplateSize size)
            {
                size.MaxWidth = "90vw";
                //size.Width = "1000px";
                //size.MaxHeight = "70vh";
                //size.Height = "800px";
            }
        };
    }
    protected override void OnSetupStarted() {
        base.OnSetupStarted();
#if DEBUG
        if(System.Diagnostics.Debugger.IsAttached && CheckCompatibilityType == CheckCompatibilityType.DatabaseSchema) {
            DatabaseUpdateMode = DatabaseUpdateMode.UpdateDatabaseAlways;
        }
#endif
    }
    private void CNTYv2BlazorApplication_DatabaseVersionMismatch(object sender, DatabaseVersionMismatchEventArgs e) {
#if EASYTEST
        e.Updater.Update();
        e.Handled = true;
#else
        if(System.Diagnostics.Debugger.IsAttached) {
            e.Updater.Update();
            e.Handled = true;
        }
        else {
            string message = "The application cannot connect to the specified database, " +
                "because the database doesn't exist, its version is older " +
                "than that of the application or its schema does not match " +
                "the ORM data model structure. To avoid this error, use one " +
                "of the solutions from the https://www.devexpress.com/kb=T367835 KB Article.";

            if(e.CompatibilityError != null && e.CompatibilityError.Exception != null) {
                message += "\r\n\r\nInner exception: " + e.CompatibilityError.Exception.Message;
            }
            throw new InvalidOperationException(message);
        }
#endif
    }
}
