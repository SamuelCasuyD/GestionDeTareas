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
   public class k2bgetcontext : GXProcedure
   {
      public k2bgetcontext( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public k2bgetcontext( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( out SdtK2BContext aP0_Context )
      {
         this.AV8Context = new SdtK2BContext(context) ;
         initialize();
         executePrivate();
         aP0_Context=this.AV8Context;
      }

      public SdtK2BContext executeUdp( )
      {
         execute(out aP0_Context);
         return AV8Context ;
      }

      public void executeSubmit( out SdtK2BContext aP0_Context )
      {
         k2bgetcontext objk2bgetcontext;
         objk2bgetcontext = new k2bgetcontext();
         objk2bgetcontext.AV8Context = new SdtK2BContext(context) ;
         objk2bgetcontext.context.SetSubmitInitialConfig(context);
         objk2bgetcontext.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objk2bgetcontext);
         aP0_Context=this.AV8Context;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bgetcontext)stateInfo).executePrivate();
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
         GXt_char1 = AV9Data;
         new k2bsessionget(context ).execute(  "Context", out  GXt_char1) ;
         AV9Data = GXt_char1;
         AV8Context.FromXml(AV9Data, null, "K2BContext", "TABLEROS_WEB");
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
         AV9Data = "";
         GXt_char1 = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private String GXt_char1 ;
      private String AV9Data ;
      private SdtK2BContext aP0_Context ;
      private SdtK2BContext AV8Context ;
   }

}
