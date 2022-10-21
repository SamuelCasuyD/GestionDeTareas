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
   public class k2bgetuseravatar : GXProcedure
   {
      public k2bgetuseravatar( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public k2bgetuseravatar( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( out String aP0_UserImage )
      {
         this.AV8UserImage = "" ;
         initialize();
         executePrivate();
         aP0_UserImage=this.AV8UserImage;
      }

      public String executeUdp( )
      {
         execute(out aP0_UserImage);
         return AV8UserImage ;
      }

      public void executeSubmit( out String aP0_UserImage )
      {
         k2bgetuseravatar objk2bgetuseravatar;
         objk2bgetuseravatar = new k2bgetuseravatar();
         objk2bgetuseravatar.AV8UserImage = "" ;
         objk2bgetuseravatar.context.SetSubmitInitialConfig(context);
         objk2bgetuseravatar.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objk2bgetuseravatar);
         aP0_UserImage=this.AV8UserImage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bgetuseravatar)stateInfo).executePrivate();
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
         AV8UserImage = "";
         AV11Userimage_GXI = "";
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
         AV11Userimage_GXI = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private String AV11Userimage_GXI ;
      private String AV8UserImage ;
      private String aP0_UserImage ;
   }

}
