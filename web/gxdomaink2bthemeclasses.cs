using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
using System.Web.Services;
using System.Data;
using GeneXus.Data;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class gxdomaink2bthemeclasses
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomaink2bthemeclasses ()
      {
         domain["TableNone"] = "TableNone";
         domain["AttributeContainerTable"] = "K2BTableGeneralData";
         domain["K2BButtonUp"] = "K2BButtonUp";
         domain["K2BButtonDown"] = "K2BButtonDown";
         domain["K2BError"] = "K2BError";
         domain["K2BMessage"] = "K2BMessage";
         domain["K2BWarning"] = "K2BWarning";
         domain["K2BSelectedTab"] = "K2BSelectedTab";
         domain["K2BUnselectedTab"] = "K2BUnselectedTab";
         domain["FilterTabContainerTable"] = "K2BTableTabFilter";
         domain["FilterContainerTable"] = "K2BTableFilterGeneralData";
         domain["K2BConfirmation"] = "K2BConfirmation";
         domain["K2BTableAttributeGroupDelimit"] = "K2BTableAttributeGroupDelimit";
         domain["ReadOnlyK2BHeaderAttribute"] = "K2BReadOnlyHeaderAttribute";
      }

      public static string getDescription( IGxContext context ,
                                           String key )
      {
         string rtkey ;
         String value ;
         rtkey = ((key==null) ? "" : StringUtil.Trim( (String)(key)));
         value = (String)(domain[rtkey]==null?"":domain[rtkey]);
         return value ;
      }

      public static GxSimpleCollection<String> getValues( )
      {
         GxSimpleCollection<String> value = new GxSimpleCollection<String>();
         ArrayList aKeys = new ArrayList(domain.Keys);
         aKeys.Sort();
         foreach (String key in aKeys)
         {
            value.Add(key);
         }
         return value;
      }

      [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
      public static String getValue( string key )
      {
         if(domainMap == null)
         {
            domainMap = new Hashtable();
            domainMap["K2BTableNone"] = "TableNone";
            domainMap["K2BTableGeneralData"] = "AttributeContainerTable";
            domainMap["K2BButtonUp"] = "K2BButtonUp";
            domainMap["K2BButtonDown"] = "K2BButtonDown";
            domainMap["K2BError"] = "K2BError";
            domainMap["K2BMessage"] = "K2BMessage";
            domainMap["K2BWarning"] = "K2BWarning";
            domainMap["K2BSelectedTab"] = "K2BSelectedTab";
            domainMap["K2BUnselectedTab"] = "K2BUnselectedTab";
            domainMap["K2BTableTabFilter"] = "FilterTabContainerTable";
            domainMap["K2BTableFilterGeneralData"] = "FilterContainerTable";
            domainMap["K2BConfirmation"] = "K2BConfirmation";
            domainMap["K2BTableAttributeGroupDelimit"] = "K2BTableAttributeGroupDelimit";
            domainMap["K2BReadOnlyHeaderAttribute"] = "ReadOnlyK2BHeaderAttribute";
         }
         return (String)domainMap[key] ;
      }

   }

}
