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
   public class k2bgetusercode : GXProcedure
   {
      public k2bgetusercode( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public k2bgetusercode( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( out String aP0_UserCode )
      {
         this.AV9UserCode = "" ;
         initialize();
         executePrivate();
         aP0_UserCode=this.AV9UserCode;
      }

      public String executeUdp( )
      {
         execute(out aP0_UserCode);
         return AV9UserCode ;
      }

      public void executeSubmit( out String aP0_UserCode )
      {
         k2bgetusercode objk2bgetusercode;
         objk2bgetusercode = new k2bgetusercode();
         objk2bgetusercode.AV9UserCode = "" ;
         objk2bgetusercode.context.SetSubmitInitialConfig(context);
         objk2bgetusercode.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objk2bgetusercode);
         aP0_UserCode=this.AV9UserCode;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bgetusercode)stateInfo).executePrivate();
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
         GXt_SdtK2BContext1 = AV8Context;
         new k2bgetcontext(context ).execute( out  GXt_SdtK2BContext1) ;
         AV8Context = GXt_SdtK2BContext1;
         AV9UserCode = AV8Context.gxTpr_Usercode;
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
         AV8Context = new SdtK2BContext(context);
         GXt_SdtK2BContext1 = new SdtK2BContext(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private String AV9UserCode ;
      private String aP0_UserCode ;
      private SdtK2BContext AV8Context ;
      private SdtK2BContext GXt_SdtK2BContext1 ;
   }

}
