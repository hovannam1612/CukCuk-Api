﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MISA.ApplicationCore.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MISA.ApplicationCore.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Nữ.
        /// </summary>
        public static string Enum_Gender_Female {
            get {
                return ResourceManager.GetString("Enum_Gender_Female", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Nam.
        /// </summary>
        public static string Enum_Gender_Male {
            get {
                return ResourceManager.GetString("Enum_Gender_Male", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Không xác định.
        /// </summary>
        public static string Enum_Gender_Other {
            get {
                return ResourceManager.GetString("Enum_Gender_Other", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Đã nghỉ việc.
        /// </summary>
        public static string Enum_WorkStatus_Resign {
            get {
                return ResourceManager.GetString("Enum_WorkStatus_Resign", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Đã nghỉ hưu.
        /// </summary>
        public static string Enum_WorkStatus_Retired {
            get {
                return ResourceManager.GetString("Enum_WorkStatus_Retired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Đang thử việc.
        /// </summary>
        public static string Enum_WorkStatus_TrainWork {
            get {
                return ResourceManager.GetString("Enum_WorkStatus_TrainWork", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Đang làm việc.
        /// </summary>
        public static string Enum_WorkStatus_Working {
            get {
                return ResourceManager.GetString("Enum_WorkStatus_Working", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Có lỗi xảy ra vui lòng liên hệ MISA.
        /// </summary>
        public static string Error_Exception {
            get {
                return ResourceManager.GetString("Error_Exception", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Xóa thành công.
        /// </summary>
        public static string Msg_Deleted {
            get {
                return ResourceManager.GetString("Msg_Deleted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Thông tin {0} đã có trên hệ thống.
        /// </summary>
        public static string Msg_Duplicated {
            get {
                return ResourceManager.GetString("Msg_Duplicated", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Thêm thành công.
        /// </summary>
        public static string Msg_Inserted {
            get {
                return ResourceManager.GetString("Msg_Inserted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Dữ liệu không hợp lệ.
        /// </summary>
        public static string Msg_IsNotValid {
            get {
                return ResourceManager.GetString("Msg_IsNotValid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Thông tin {0} không được phép để trống.
        /// </summary>
        public static string Msg_Required {
            get {
                return ResourceManager.GetString("Msg_Required", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Sửa thành công.
        /// </summary>
        public static string Msg_Updated {
            get {
                return ResourceManager.GetString("Msg_Updated", resourceCulture);
            }
        }
    }
}
