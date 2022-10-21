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
   public class k2btoolsmessagequeuegetallmessages : GXProcedure
   {
      public k2btoolsmessagequeuegetallmessages( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public k2btoolsmessagequeuegetallmessages( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( out GXBaseCollection<SdtMessages_Message> aP0_Messages )
      {
         this.AV8Messages = new GXBaseCollection<SdtMessages_Message>( context, "Message", "GeneXus") ;
         initialize();
         executePrivate();
         aP0_Messages=this.AV8Messages;
      }

      public GXBaseCollection<SdtMessages_Message> executeUdp( )
      {
         execute(out aP0_Messages);
         return AV8Messages ;
      }

      public void executeSubmit( out GXBaseCollection<SdtMessages_Message> aP0_Messages )
      {
         k2btoolsmessagequeuegetallmessages objk2btoolsmessagequeuegetallmessages;
         objk2btoolsmessagequeuegetallmessages = new k2btoolsmessagequeuegetallmessages();
         objk2btoolsmessagequeuegetallmessages.AV8Messages = new GXBaseCollection<SdtMessages_Message>( context, "Message", "GeneXus") ;
         objk2btoolsmessagequeuegetallmessages.context.SetSubmitInitialConfig(context);
         objk2btoolsmessagequeuegetallmessages.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objk2btoolsmessagequeuegetallmessages);
         aP0_Messages=this.AV8Messages;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2btoolsmessagequeuegetallmessages)stateInfo).executePrivate();
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
         AV10SessionString = AV9Session.Get("K2BToolsMessageQueue_Content");
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV10SessionString)) ) )
         {
            AV8Messages.FromJSonString(AV10SessionString, null);
            AV9Session.Remove("K2BToolsMessageQueue_Content");
         }
         else
         {
            AV8Messages = new GXBaseCollection<SdtMessages_Message>( context, "Message", "GeneXus");
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
         AV10SessionString = "";
         AV9Session = context.GetSession();
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private String AV10SessionString ;
      private IGxSession AV9Session ;
      private GXBaseCollection<SdtMessages_Message> aP0_Messages ;
      private GXBaseCollection<SdtMessages_Message> AV8Messages ;
   }

}
