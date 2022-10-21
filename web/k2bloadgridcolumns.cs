using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class k2bloadgridcolumns : GXProcedure
   {
      public k2bloadgridcolumns( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public k2bloadgridcolumns( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( String aP0_ProgramName ,
                           String aP1_GridName ,
                           ref GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> aP2_GridColumns )
      {
         this.AV15ProgramName = aP0_ProgramName;
         this.AV14GridName = aP1_GridName;
         this.AV12GridColumns = aP2_GridColumns;
         initialize();
         executePrivate();
         aP2_GridColumns=this.AV12GridColumns;
      }

      public GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> executeUdp( String aP0_ProgramName ,
                                                                                String aP1_GridName )
      {
         execute(aP0_ProgramName, aP1_GridName, ref aP2_GridColumns);
         return AV12GridColumns ;
      }

      public void executeSubmit( String aP0_ProgramName ,
                                 String aP1_GridName ,
                                 ref GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> aP2_GridColumns )
      {
         k2bloadgridcolumns objk2bloadgridcolumns;
         objk2bloadgridcolumns = new k2bloadgridcolumns();
         objk2bloadgridcolumns.AV15ProgramName = aP0_ProgramName;
         objk2bloadgridcolumns.AV14GridName = aP1_GridName;
         objk2bloadgridcolumns.AV12GridColumns = aP2_GridColumns;
         objk2bloadgridcolumns.context.SetSubmitInitialConfig(context);
         objk2bloadgridcolumns.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objk2bloadgridcolumns);
         aP2_GridColumns=this.AV12GridColumns;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bloadgridcolumns)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw e ;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV17SessionString = AV16Session.Get(StringUtil.Trim( AV15ProgramName)+"#"+StringUtil.Trim( AV14GridName)+"GridColumns");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17SessionString)) )
         {
            AV12GridColumns.FromJSonString(AV17SessionString, null);
         }
         else
         {
            AV13GridColumnsDB.FromJSonString(AV12GridColumns.ToJSonString(false), null);
            new k2bretrievegridcolumns(context ).execute(  AV15ProgramName,  AV14GridName, out  AV13GridColumnsDB) ;
            AV21GXV1 = 1;
            while ( AV21GXV1 <= AV12GridColumns.Count )
            {
               AV10GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV12GridColumns.Item(AV21GXV1));
               AV8AttributeName = AV10GridColumn.gxTpr_Attributename;
               /* Execute user subroutine: 'FINDGRIDCOLUMNDB' */
               S111 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
               if ( AV9Found )
               {
                  AV10GridColumn.gxTpr_Showattribute = AV18ShowAttribute;
               }
               AV21GXV1 = (int)(AV21GXV1+1);
            }
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'FINDGRIDCOLUMNDB' Routine */
         AV9Found = false;
         AV22GXV2 = 1;
         while ( AV22GXV2 <= AV13GridColumnsDB.Count )
         {
            AV11GridColumnDB = ((SdtK2BGridColumns_K2BGridColumnsItem)AV13GridColumnsDB.Item(AV22GXV2));
            if ( StringUtil.StrCmp(AV11GridColumnDB.gxTpr_Attributename, AV8AttributeName) == 0 )
            {
               AV9Found = true;
               AV18ShowAttribute = AV11GridColumnDB.gxTpr_Showattribute;
               if (true) break;
            }
            AV22GXV2 = (int)(AV22GXV2+1);
         }
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections() ;
         }
         exitApplication();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         AV17SessionString = "";
         AV16Session = context.GetSession();
         AV13GridColumnsDB = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "TABLEROS_WEB");
         AV10GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV8AttributeName = "";
         AV11GridColumnDB = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV21GXV1 ;
      private int AV22GXV2 ;
      private String AV15ProgramName ;
      private String AV14GridName ;
      private String AV17SessionString ;
      private String AV8AttributeName ;
      private bool returnInSub ;
      private bool AV9Found ;
      private bool AV18ShowAttribute ;
      private IGxSession AV16Session ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> aP2_GridColumns ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV12GridColumns ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV13GridColumnsDB ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV10GridColumn ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV11GridColumnDB ;
   }

}
