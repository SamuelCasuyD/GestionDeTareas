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
   public class k2bsettrncontextbyname : GXProcedure
   {
      public k2bsettrncontextbyname( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public k2bsettrncontextbyname( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( String aP0_TransactionName ,
                           SdtK2BTrnContext aP1_TrnContext )
      {
         this.AV10TransactionName = aP0_TransactionName;
         this.AV9TrnContext = aP1_TrnContext;
         initialize();
         executePrivate();
      }

      public void executeSubmit( String aP0_TransactionName ,
                                 SdtK2BTrnContext aP1_TrnContext )
      {
         k2bsettrncontextbyname objk2bsettrncontextbyname;
         objk2bsettrncontextbyname = new k2bsettrncontextbyname();
         objk2bsettrncontextbyname.AV10TransactionName = aP0_TransactionName;
         objk2bsettrncontextbyname.AV9TrnContext = aP1_TrnContext;
         objk2bsettrncontextbyname.context.SetSubmitInitialConfig(context);
         objk2bsettrncontextbyname.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objk2bsettrncontextbyname);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bsettrncontextbyname)stateInfo).executePrivate();
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
         AV8Data = AV9TrnContext.ToXml(false, true, "K2BTrnContext", "TABLEROS_WEB");
         new k2bsessionset(context ).execute(  "TrnContext"+":"+AV10TransactionName,  AV8Data) ;
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
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private String AV8Data ;
      private String AV10TransactionName ;
      private SdtK2BTrnContext AV9TrnContext ;
   }

}
