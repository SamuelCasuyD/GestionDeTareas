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
   public class gxdomaink2bcomponenttype
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomaink2bcomponenttype ()
      {
         domain[(short)1] = "SubWorkWith";
         domain[(short)2] = "UserDefined";
         domain[(short)3] = "MainTransaction";
         domain[(short)4] = "ParalelTransaction";
         domain[(short)5] = "History";
      }

      public static string getDescription( IGxContext context ,
                                           short key )
      {
         String value ;
         value = (String)(domain[key]==null?"":domain[key]);
         return value ;
      }

      public static GxSimpleCollection<short> getValues( )
      {
         GxSimpleCollection<short> value = new GxSimpleCollection<short>();
         ArrayList aKeys = new ArrayList(domain.Keys);
         aKeys.Sort();
         foreach (short key in aKeys)
         {
            value.Add(key);
         }
         return value;
      }

      [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
      public static short getValue( string key )
      {
         if(domainMap == null)
         {
            domainMap = new Hashtable();
            domainMap["SubWorkWith"] = (short)1;
            domainMap["UserDefined"] = (short)2;
            domainMap["MainTransaction"] = (short)3;
            domainMap["ParalelTransaction"] = (short)4;
            domainMap["History"] = (short)5;
         }
         return (short)domainMap[key] ;
      }

   }

}
