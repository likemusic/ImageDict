﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.239
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ImageDict.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Content.txt")]
        public string DefaultContentsListFilename {
            get {
                return ((string)(this["DefaultContentsListFilename"]));
            }
            set {
                this["DefaultContentsListFilename"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Data")]
        public string DefaultSourceDir {
            get {
                return ((string)(this["DefaultSourceDir"]));
            }
            set {
                this["DefaultSourceDir"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int DefaultStartOffset {
            get {
                return ((int)(this["DefaultStartOffset"]));
            }
            set {
                this["DefaultStartOffset"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0000")]
        public string DefaultFileFormatString {
            get {
                return ((string)(this["DefaultFileFormatString"]));
            }
            set {
                this["DefaultFileFormatString"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Settings.json")]
        public string DefaultSettingsFilename {
            get {
                return ((string)(this["DefaultSettingsFilename"]));
            }
            set {
                this["DefaultSettingsFilename"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(";")]
        public string DefaultContentColumnSeparator {
            get {
                return ((string)(this["DefaultContentColumnSeparator"]));
            }
            set {
                this["DefaultContentColumnSeparator"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool DefaultContentHaveEnds {
            get {
                return ((bool)(this["DefaultContentHaveEnds"]));
            }
            set {
                this["DefaultContentHaveEnds"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("По размеру страницы")]
        public string ScaleBySize {
            get {
                return ((string)(this["ScaleBySize"]));
            }
            set {
                this["ScaleBySize"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("По высоте")]
        public string ScaleByHeight {
            get {
                return ((string)(this["ScaleByHeight"]));
            }
            set {
                this["ScaleByHeight"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("По ширине")]
        public string ScaleByWidth {
            get {
                return ((string)(this["ScaleByWidth"]));
            }
            set {
                this["ScaleByWidth"] = value;
            }
        }
    }
}
