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
   public class k2bgetmultiplefiltervaluesummary : GXProcedure
   {
      public k2bgetmultiplefiltervaluesummary( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public k2bgetmultiplefiltervaluesummary( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_MultipleValuesItem> aP0_Values ,
                           out String aP1_Result )
      {
         this.AV8Values = aP0_Values;
         this.AV9Result = "" ;
         initialize();
         executePrivate();
         aP1_Result=this.AV9Result;
      }

      public String executeUdp( GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_MultipleValuesItem> aP0_Values )
      {
         execute(aP0_Values, out aP1_Result);
         return AV9Result ;
      }

      public void executeSubmit( GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_MultipleValuesItem> aP0_Values ,
                                 out String aP1_Result )
      {
         k2bgetmultiplefiltervaluesummary objk2bgetmultiplefiltervaluesummary;
         objk2bgetmultiplefiltervaluesummary = new k2bgetmultiplefiltervaluesummary();
         objk2bgetmultiplefiltervaluesummary.AV8Values = aP0_Values;
         objk2bgetmultiplefiltervaluesummary.AV9Result = "" ;
         objk2bgetmultiplefiltervaluesummary.context.SetSubmitInitialConfig(context);
         objk2bgetmultiplefiltervaluesummary.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objk2bgetmultiplefiltervaluesummary);
         aP1_Result=this.AV9Result;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bgetmultiplefiltervaluesummary)stateInfo).executePrivate();
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
         if ( ( AV8Values.Count > 0 ) && ( AV8Values.Count < 4 ) )
         {
            AV9Result = ((SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_MultipleValuesItem)AV8Values.Item(1)).gxTpr_Itemdescription;
            AV10i = 2;
            while ( AV10i <= AV8Values.Count )
            {
               AV9Result = AV9Result + ", " + StringUtil.Trim( ((SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_MultipleValuesItem)AV8Values.Item(AV10i)).gxTpr_Itemdescription);
               AV10i = (short)(AV10i+1);
            }
         }
         else
         {
            if ( AV8Values.Count >= 4 )
            {
               AV9Result = ((SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_MultipleValuesItem)AV8Values.Item(1)).gxTpr_Itemdescription;
               AV9Result = AV9Result + ", " + StringUtil.Trim( ((SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_MultipleValuesItem)AV8Values.Item(2)).gxTpr_Itemdescription);
               AV9Result = AV9Result + ", " + StringUtil.Trim( ((SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_MultipleValuesItem)AV8Values.Item(3)).gxTpr_Itemdescription);
               AV9Result = AV9Result + StringUtil.Format( " (+%1)", StringUtil.LTrimStr( (decimal)((AV8Values.Count-3)), 9, 0), "", "", "", "", "", "", "", "");
            }
            else
            {
               AV9Result = "Todo";
            }
         }
         this.cleanup();
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
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV10i ;
      private String AV9Result ;
      private String aP1_Result ;
      private GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem_MultipleValuesItem> AV8Values ;
   }

}
