﻿using System.ComponentModel.Composition;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using Dynamics.AX.Application;
using Microsoft.Dynamics.Framework.Tools.Extensibility;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Classes;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Forms;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Tables;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Core;
using Exception = System.Exception;

namespace TRUDUtilsD365.CreateExtensionClass
{
    [Export(typeof(IDesignerMenu))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(ClassItem))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(IForm))]
    [DesignerMenuExportMetadata(AutomationNodeType = typeof(Table))]
    internal class DesignerCreateExtensionClass : DesignerMenuBase
    {
        #region Properties
        /// <summary>
        ///     Caption for the menu item. This is what users would see in the menu.
        /// </summary>
        public override string Caption => "Create extension class";

        private const string AddinName = "TRUDUtilsD365.CreateExtensionClass";
        /// <summary>
        ///     Unique name of the add-in
        /// </summary>
        public override string Name => AddinName;
        #endregion

        #region Callbacks

        /// <summary>
        ///     Called when user clicks on the add-in menu
        /// </summary>
        /// <param name="e">The context of the VS tools and metadata</param>
        [SuppressMessage("ReSharper", "MergeCastWithTypeCheck")]
        public override void OnClick(AddinDesignerEventArgs e)
        {
            try
            {
                CreateExtensionClassDialog dialog = new CreateExtensionClassDialog();
                CreateExtensionClassParms parms = new CreateExtensionClassParms();

                if (e.SelectedElement is IForm)
                {
                    var form = (IForm) e.SelectedElement;
                    parms.ElementType = UtilElementType.Form;
                    parms.ElementName = form.Name;
                }

                if (e.SelectedElement is ClassItem)
                {
                    var form = (ClassItem) e.SelectedElement;
                    parms.ElementType = UtilElementType.Class;
                    parms.ElementName = form.Name;
                }

                if (e.SelectedElement is Table)
                {
                    var form = (Table) e.SelectedElement;
                    parms.ElementType = UtilElementType.Table;
                    parms.ElementName = form.Name;
                }

                //parms.MethodName = "find";
                dialog.SetParameters(parms);
                DialogResult formRes = dialog.ShowDialog();
                if (formRes == DialogResult.OK) parms.CreateClass();
            }
            catch (Exception ex)
            {
                CoreUtility.HandleExceptionWithErrorMessage(ex);
            }
        }

        #endregion


    }
}