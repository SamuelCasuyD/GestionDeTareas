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
   public class k2bgettrncontextbyname : GXProcedure
   {
      public k2bgettrncontextbyname( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public k2bgettrncontextbyname( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( String aP0_TransactionName ,
                           out SdtK2BTrnContext aP1_TrnContext )
      {
         this.AV10TransactionName = aP0_TransactionName;
         this.AV9TrnContext = new SdtK2BTrnContext(context) ;
         initialize();
         executePrivate();
         aP1_TrnContext=this.AV9TrnContext;
      }

      public SdtK2BTrnContext executeUdp( String aP0_TransactionName )
      {
         execute(aP0_TransactionName, out aP1_TrnContext);
         return AV9TrnContext ;
      }

      public void executeSubmit( String aP0_TransactionName ,
                                 out SdtK2BTrnContext aP1_TrnContext )
      {
         k2bgettrncontextbyname objk2bgettrncontextbyname;
         objk2bgettrncontextbyname = new k2bgettrncontextbyname();
         objk2bgettrncontextbyname.AV10TransactionName = aP0_TransactionName;
         objk2bgettrncontextbyname.AV9TrnContext = new SdtK2BTrnContext(context) ;
         objk2bgettrncontextbyname.context.SetSubmitInitialConfig(context);
         objk2bgettrncontextbyname.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objk2bgettrncontextbyname);
         aP1_TrnContext=this.AV9TrnContext;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bgettrncontextbyname)stateInfo).executePrivate();
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
         GXt_char1 = AV8Data;
         new k2bsessionget(context ).execute(  "TrnContext"+":"+AV10TransactionName, out  GXt_char1) ;
         AV8Data = GXt_char1;
         AV9TrnContext.FromXml(AV8Data, null, "K2BTrnContext", "TABLEROS_WEB");
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
         AV8Data = "";
         GXt_char1 = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private String GXt_char1 ;
      private String AV8Data ;
      private String AV10TransactionName ;
      private SdtK2BTrnContext aP1_TrnContext ;
      private SdtK2BTrnContext AV9TrnContext ;
   }

}
