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
   public class gxdomaink2bsesitem
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomaink2bsesitem ()
      {
         domain["Context"] = "Context";
         domain["Stack"] = "Stack";
         domain["StackCaption"] = "StackCaption";
         domain["TrnContext"] = "TrnContext";
         domain["Messages"] = "Messages";
         domain["WorkFlowContext"] = "WorkFlowContext";
         domain["ComponentContext"] = "ComponentContext";
         domain["GXPortalMessage"] = "GXPortalMessage";
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
            domainMap["Context"] = "Context";
            domainMap["Stack"] = "Stack";
            domainMap["StackCaption"] = "StackCaption";
            domainMap["TrnContext"] = "TrnContext";
            domainMap["Messages"] = "Messages";
            domainMap["WorkFlowContext"] = "WorkFlowContext";
            domainMap["ComponentContext"] = "ComponentContext";
            domainMap["GXPortalMessage"] = "GXPortalMessage";
         }
         return (String)domainMap[key] ;
      }

   }

}
