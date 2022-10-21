using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class trtareacomentarios : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetNextPar( );
         gxfirstwebparm_bkp = gxfirstwebparm;
         gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            dyncall( GetNextPar( )) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A34TrTareaComentarios_IDTarea = (long)(NumberUtil.Val( GetNextPar( ), "."));
            n34TrTareaComentarios_IDTarea = false;
            AssignAttri("", false, "A34TrTareaComentarios_IDTarea", StringUtil.LTrimStr( (decimal)(A34TrTareaComentarios_IDTarea), 13, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A34TrTareaComentarios_IDTarea) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
         {
            setAjaxEventMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetNextPar( );
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetNextPar( );
         }
         else
         {
            if ( ! IsValidAjaxCall( false) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = gxfirstwebparm_bkp;
         }
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", 0);
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_web_controls( ) ;
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus C# 16_0_10-142546", 0) ;
            }
            Form.Meta.addItem("description", "Tr Tarea Comentarios", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         GX_FocusControl = edtTrTareaComentarios_ID_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         wbErr = false;
         context.SetDefaultTheme("K2BOrion");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trtareacomentarios( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public trtareacomentarios( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( )
      {
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbTrTareaComentarios_Estado = new GXCombobox();
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("k2bwwmasterpageorion", "GeneXus.Programs.k2bwwmasterpageorion", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         this.cleanup();
      }

      protected void fix_multi_value_controls( )
      {
         if ( cmbTrTareaComentarios_Estado.ItemCount > 0 )
         {
            A37TrTareaComentarios_Estado = (short)(NumberUtil.Val( cmbTrTareaComentarios_Estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A37TrTareaComentarios_Estado), 4, 0))), "."));
            n37TrTareaComentarios_Estado = false;
            AssignAttri("", false, "A37TrTareaComentarios_Estado", StringUtil.LTrimStr( (decimal)(A37TrTareaComentarios_Estado), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTrTareaComentarios_Estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A37TrTareaComentarios_Estado), 4, 0));
            AssignProp("", false, cmbTrTareaComentarios_Estado_Internalname, "Values", cmbTrTareaComentarios_Estado.ToJavascriptSource(), true);
         }
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "Container FormContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Tr Tarea Comentarios", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, "HLP_TrTareaComentarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 12,'',false,'',0)\"";
         ClassString = "BtnFirst";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrTareaComentarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrTareaComentarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrTareaComentarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrTareaComentarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 4, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx0050.aspx"+"',["+"{Ctrl:gx.dom.el('"+"TRTAREACOMENTARIOS_ID"+"'), id:'"+"TRTAREACOMENTARIOS_ID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_TrTareaComentarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3", "left", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrTareaComentarios_ID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrTareaComentarios_ID_Internalname, "Tarea Comentarios_ID", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrTareaComentarios_ID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A35TrTareaComentarios_ID), 13, 0, ".", "")), ((edtTrTareaComentarios_ID_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A35TrTareaComentarios_ID), "ZZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A35TrTareaComentarios_ID), "ZZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrTareaComentarios_ID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrTareaComentarios_ID_Enabled, 0, "number", "1", 13, "chr", 1, "row", 13, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TrTareaComentarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrTareaComentarios_IDTarea_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrTareaComentarios_IDTarea_Internalname, "Tarea Comentarios_IDTarea", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTrTareaComentarios_IDTarea_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A34TrTareaComentarios_IDTarea), 13, 0, ".", "")), ((edtTrTareaComentarios_IDTarea_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A34TrTareaComentarios_IDTarea), "ZZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A34TrTareaComentarios_IDTarea), "ZZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrTareaComentarios_IDTarea_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrTareaComentarios_IDTarea_Enabled, 0, "number", "1", 13, "chr", 1, "row", 13, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TrTareaComentarios.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (String)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_34_Internalname, sImgUrl, imgprompt_34_Link, "", "", context.GetTheme( ), imgprompt_34_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_TrTareaComentarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrTareaComentarios_Descripcion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrTareaComentarios_Descripcion_Internalname, "Tarea Comentarios_Descripcion", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtTrTareaComentarios_Descripcion_Internalname, A36TrTareaComentarios_Descripcion, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", 0, 1, edtTrTareaComentarios_Descripcion_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_TrTareaComentarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbTrTareaComentarios_Estado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbTrTareaComentarios_Estado_Internalname, "Tarea Comentarios_Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbTrTareaComentarios_Estado, cmbTrTareaComentarios_Estado_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A37TrTareaComentarios_Estado), 4, 0)), 1, cmbTrTareaComentarios_Estado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbTrTareaComentarios_Estado.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "", true, "HLP_TrTareaComentarios.htm");
         cmbTrTareaComentarios_Estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A37TrTareaComentarios_Estado), 4, 0));
         AssignProp("", false, cmbTrTareaComentarios_Estado_Internalname, "Values", (String)(cmbTrTareaComentarios_Estado.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrTareaComentarios_FechaCreacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrTareaComentarios_FechaCreacion_Internalname, "Comentarios_Fecha Creacion", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTrTareaComentarios_FechaCreacion_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTrTareaComentarios_FechaCreacion_Internalname, context.localUtil.Format(A38TrTareaComentarios_FechaCreacion, "99/99/9999"), context.localUtil.Format( A38TrTareaComentarios_FechaCreacion, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrTareaComentarios_FechaCreacion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrTareaComentarios_FechaCreacion_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "FechaCompleta", "right", false, "", "HLP_TrTareaComentarios.htm");
         GxWebStd.gx_bitmap( context, edtTrTareaComentarios_FechaCreacion_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTrTareaComentarios_FechaCreacion_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TrTareaComentarios.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTrTareaComentarios_FechaModificacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTrTareaComentarios_FechaModificacion_Internalname, "Comentarios_Fecha Modificacion", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTrTareaComentarios_FechaModificacion_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTrTareaComentarios_FechaModificacion_Internalname, context.localUtil.Format(A39TrTareaComentarios_FechaModificacion, "99/99/9999"), context.localUtil.Format( A39TrTareaComentarios_FechaModificacion, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTrTareaComentarios_FechaModificacion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTrTareaComentarios_FechaModificacion_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "FechaCompleta", "right", false, "", "HLP_TrTareaComentarios.htm");
         GxWebStd.gx_bitmap( context, edtTrTareaComentarios_FechaModificacion_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTrTareaComentarios_FechaModificacion_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TrTareaComentarios.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group Confirm", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrTareaComentarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrTareaComentarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_TrTareaComentarios.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Z35TrTareaComentarios_ID = (long)(context.localUtil.CToN( cgiGet( "Z35TrTareaComentarios_ID"), ".", ","));
            Z37TrTareaComentarios_Estado = (short)(context.localUtil.CToN( cgiGet( "Z37TrTareaComentarios_Estado"), ".", ","));
            n37TrTareaComentarios_Estado = ((0==A37TrTareaComentarios_Estado) ? true : false);
            Z38TrTareaComentarios_FechaCreacion = context.localUtil.CToD( cgiGet( "Z38TrTareaComentarios_FechaCreacion"), 0);
            n38TrTareaComentarios_FechaCreacion = ((DateTime.MinValue==A38TrTareaComentarios_FechaCreacion) ? true : false);
            Z39TrTareaComentarios_FechaModificacion = context.localUtil.CToD( cgiGet( "Z39TrTareaComentarios_FechaModificacion"), 0);
            n39TrTareaComentarios_FechaModificacion = ((DateTime.MinValue==A39TrTareaComentarios_FechaModificacion) ? true : false);
            Z34TrTareaComentarios_IDTarea = (long)(context.localUtil.CToN( cgiGet( "Z34TrTareaComentarios_IDTarea"), ".", ","));
            n34TrTareaComentarios_IDTarea = ((0==A34TrTareaComentarios_IDTarea) ? true : false);
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtTrTareaComentarios_ID_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTrTareaComentarios_ID_Internalname), ".", ",") > Convert.ToDecimal( 9999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TRTAREACOMENTARIOS_ID");
               AnyError = 1;
               GX_FocusControl = edtTrTareaComentarios_ID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A35TrTareaComentarios_ID = 0;
               AssignAttri("", false, "A35TrTareaComentarios_ID", StringUtil.LTrimStr( (decimal)(A35TrTareaComentarios_ID), 13, 0));
            }
            else
            {
               A35TrTareaComentarios_ID = (long)(context.localUtil.CToN( cgiGet( edtTrTareaComentarios_ID_Internalname), ".", ","));
               AssignAttri("", false, "A35TrTareaComentarios_ID", StringUtil.LTrimStr( (decimal)(A35TrTareaComentarios_ID), 13, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtTrTareaComentarios_IDTarea_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTrTareaComentarios_IDTarea_Internalname), ".", ",") > Convert.ToDecimal( 9999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TRTAREACOMENTARIOS_IDTAREA");
               AnyError = 1;
               GX_FocusControl = edtTrTareaComentarios_IDTarea_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A34TrTareaComentarios_IDTarea = 0;
               n34TrTareaComentarios_IDTarea = false;
               AssignAttri("", false, "A34TrTareaComentarios_IDTarea", StringUtil.LTrimStr( (decimal)(A34TrTareaComentarios_IDTarea), 13, 0));
            }
            else
            {
               A34TrTareaComentarios_IDTarea = (long)(context.localUtil.CToN( cgiGet( edtTrTareaComentarios_IDTarea_Internalname), ".", ","));
               n34TrTareaComentarios_IDTarea = false;
               AssignAttri("", false, "A34TrTareaComentarios_IDTarea", StringUtil.LTrimStr( (decimal)(A34TrTareaComentarios_IDTarea), 13, 0));
            }
            n34TrTareaComentarios_IDTarea = ((0==A34TrTareaComentarios_IDTarea) ? true : false);
            A36TrTareaComentarios_Descripcion = cgiGet( edtTrTareaComentarios_Descripcion_Internalname);
            n36TrTareaComentarios_Descripcion = false;
            AssignAttri("", false, "A36TrTareaComentarios_Descripcion", A36TrTareaComentarios_Descripcion);
            n36TrTareaComentarios_Descripcion = (String.IsNullOrEmpty(StringUtil.RTrim( A36TrTareaComentarios_Descripcion)) ? true : false);
            cmbTrTareaComentarios_Estado.CurrentValue = cgiGet( cmbTrTareaComentarios_Estado_Internalname);
            A37TrTareaComentarios_Estado = (short)(NumberUtil.Val( cgiGet( cmbTrTareaComentarios_Estado_Internalname), "."));
            n37TrTareaComentarios_Estado = false;
            AssignAttri("", false, "A37TrTareaComentarios_Estado", StringUtil.LTrimStr( (decimal)(A37TrTareaComentarios_Estado), 4, 0));
            n37TrTareaComentarios_Estado = ((0==A37TrTareaComentarios_Estado) ? true : false);
            if ( context.localUtil.VCDate( cgiGet( edtTrTareaComentarios_FechaCreacion_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Tarea Comentarios_Fecha Creacion"}), 1, "TRTAREACOMENTARIOS_FECHACREACION");
               AnyError = 1;
               GX_FocusControl = edtTrTareaComentarios_FechaCreacion_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A38TrTareaComentarios_FechaCreacion = DateTime.MinValue;
               n38TrTareaComentarios_FechaCreacion = false;
               AssignAttri("", false, "A38TrTareaComentarios_FechaCreacion", context.localUtil.Format(A38TrTareaComentarios_FechaCreacion, "99/99/9999"));
            }
            else
            {
               A38TrTareaComentarios_FechaCreacion = context.localUtil.CToD( cgiGet( edtTrTareaComentarios_FechaCreacion_Internalname), 1);
               n38TrTareaComentarios_FechaCreacion = false;
               AssignAttri("", false, "A38TrTareaComentarios_FechaCreacion", context.localUtil.Format(A38TrTareaComentarios_FechaCreacion, "99/99/9999"));
            }
            n38TrTareaComentarios_FechaCreacion = ((DateTime.MinValue==A38TrTareaComentarios_FechaCreacion) ? true : false);
            if ( context.localUtil.VCDate( cgiGet( edtTrTareaComentarios_FechaModificacion_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Tr Tarea Comentarios_Fecha Modificacion"}), 1, "TRTAREACOMENTARIOS_FECHAMODIFICACION");
               AnyError = 1;
               GX_FocusControl = edtTrTareaComentarios_FechaModificacion_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A39TrTareaComentarios_FechaModificacion = DateTime.MinValue;
               n39TrTareaComentarios_FechaModificacion = false;
               AssignAttri("", false, "A39TrTareaComentarios_FechaModificacion", context.localUtil.Format(A39TrTareaComentarios_FechaModificacion, "99/99/9999"));
            }
            else
            {
               A39TrTareaComentarios_FechaModificacion = context.localUtil.CToD( cgiGet( edtTrTareaComentarios_FechaModificacion_Internalname), 1);
               n39TrTareaComentarios_FechaModificacion = false;
               AssignAttri("", false, "A39TrTareaComentarios_FechaModificacion", context.localUtil.Format(A39TrTareaComentarios_FechaModificacion, "99/99/9999"));
            }
            n39TrTareaComentarios_FechaModificacion = ((DateTime.MinValue==A39TrTareaComentarios_FechaModificacion) ? true : false);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               A35TrTareaComentarios_ID = (long)(NumberUtil.Val( GetNextPar( ), "."));
               AssignAttri("", false, "A35TrTareaComentarios_ID", StringUtil.LTrimStr( (decimal)(A35TrTareaComentarios_ID), 13, 0));
               getEqualNoModal( ) ;
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               disable_std_buttons_dsp( ) ;
               standaloneModal( ) ;
            }
            else
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               standaloneModal( ) ;
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
            sEvt = cgiGet( "_EventName");
            EvtGridId = cgiGet( "_EventGridId");
            EvtRowId = cgiGet( "_EventRowId");
            if ( StringUtil.Len( sEvt) > 0 )
            {
               sEvtType = StringUtil.Left( sEvt, 1);
               sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
               if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
               {
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_enter( ) ;
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_first( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "PREVIOUS") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_previous( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_next( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_last( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "SELECT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_select( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DELETE") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_delete( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           AfterKeyLoadScreen( ) ;
                        }
                     }
                     else
                     {
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll055( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
      }

      public override String ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         if ( IsIns( ) )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
      }

      protected void disable_std_buttons_dsp( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) )
         {
            bttBtn_enter_Visible = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
         }
         DisableAttributes055( ) ;
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void ResetCaption050( )
      {
      }

      protected void ZM055( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z37TrTareaComentarios_Estado = T00053_A37TrTareaComentarios_Estado[0];
               Z38TrTareaComentarios_FechaCreacion = T00053_A38TrTareaComentarios_FechaCreacion[0];
               Z39TrTareaComentarios_FechaModificacion = T00053_A39TrTareaComentarios_FechaModificacion[0];
               Z34TrTareaComentarios_IDTarea = T00053_A34TrTareaComentarios_IDTarea[0];
            }
            else
            {
               Z37TrTareaComentarios_Estado = A37TrTareaComentarios_Estado;
               Z38TrTareaComentarios_FechaCreacion = A38TrTareaComentarios_FechaCreacion;
               Z39TrTareaComentarios_FechaModificacion = A39TrTareaComentarios_FechaModificacion;
               Z34TrTareaComentarios_IDTarea = A34TrTareaComentarios_IDTarea;
            }
         }
         if ( GX_JID == -4 )
         {
            Z35TrTareaComentarios_ID = A35TrTareaComentarios_ID;
            Z36TrTareaComentarios_Descripcion = A36TrTareaComentarios_Descripcion;
            Z37TrTareaComentarios_Estado = A37TrTareaComentarios_Estado;
            Z38TrTareaComentarios_FechaCreacion = A38TrTareaComentarios_FechaCreacion;
            Z39TrTareaComentarios_FechaModificacion = A39TrTareaComentarios_FechaModificacion;
            Z34TrTareaComentarios_IDTarea = A34TrTareaComentarios_IDTarea;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_34_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0020.aspx"+"',["+"{Ctrl:gx.dom.el('"+"TRTAREACOMENTARIOS_IDTAREA"+"'), id:'"+"TRTAREACOMENTARIOS_IDTAREA"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_delete_Enabled = 1;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
      }

      protected void Load055( )
      {
         /* Using cursor T00055 */
         pr_default.execute(3, new Object[] {A35TrTareaComentarios_ID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound5 = 1;
            A36TrTareaComentarios_Descripcion = T00055_A36TrTareaComentarios_Descripcion[0];
            n36TrTareaComentarios_Descripcion = T00055_n36TrTareaComentarios_Descripcion[0];
            AssignAttri("", false, "A36TrTareaComentarios_Descripcion", A36TrTareaComentarios_Descripcion);
            A37TrTareaComentarios_Estado = T00055_A37TrTareaComentarios_Estado[0];
            n37TrTareaComentarios_Estado = T00055_n37TrTareaComentarios_Estado[0];
            AssignAttri("", false, "A37TrTareaComentarios_Estado", StringUtil.LTrimStr( (decimal)(A37TrTareaComentarios_Estado), 4, 0));
            A38TrTareaComentarios_FechaCreacion = T00055_A38TrTareaComentarios_FechaCreacion[0];
            n38TrTareaComentarios_FechaCreacion = T00055_n38TrTareaComentarios_FechaCreacion[0];
            AssignAttri("", false, "A38TrTareaComentarios_FechaCreacion", context.localUtil.Format(A38TrTareaComentarios_FechaCreacion, "99/99/9999"));
            A39TrTareaComentarios_FechaModificacion = T00055_A39TrTareaComentarios_FechaModificacion[0];
            n39TrTareaComentarios_FechaModificacion = T00055_n39TrTareaComentarios_FechaModificacion[0];
            AssignAttri("", false, "A39TrTareaComentarios_FechaModificacion", context.localUtil.Format(A39TrTareaComentarios_FechaModificacion, "99/99/9999"));
            A34TrTareaComentarios_IDTarea = T00055_A34TrTareaComentarios_IDTarea[0];
            n34TrTareaComentarios_IDTarea = T00055_n34TrTareaComentarios_IDTarea[0];
            AssignAttri("", false, "A34TrTareaComentarios_IDTarea", StringUtil.LTrimStr( (decimal)(A34TrTareaComentarios_IDTarea), 13, 0));
            ZM055( -4) ;
         }
         pr_default.close(3);
         OnLoadActions055( ) ;
      }

      protected void OnLoadActions055( )
      {
      }

      protected void CheckExtendedTable055( )
      {
         nIsDirty_5 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00054 */
         pr_default.execute(2, new Object[] {n34TrTareaComentarios_IDTarea, A34TrTareaComentarios_IDTarea});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A34TrTareaComentarios_IDTarea) ) )
            {
               GX_msglist.addItem("No matching 'Tr Gestion Tareas2_STG'.", "ForeignKeyNotFound", 1, "TRTAREACOMENTARIOS_IDTAREA");
               AnyError = 1;
               GX_FocusControl = edtTrTareaComentarios_IDTarea_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(2);
         if ( ! ( ( A37TrTareaComentarios_Estado == 1 ) || ( A37TrTareaComentarios_Estado == 2 ) || ( A37TrTareaComentarios_Estado == 3 ) || (0==A37TrTareaComentarios_Estado) ) )
         {
            GX_msglist.addItem("Field Tr Tarea Comentarios_Estado is out of range", "OutOfRange", 1, "TRTAREACOMENTARIOS_ESTADO");
            AnyError = 1;
            GX_FocusControl = cmbTrTareaComentarios_Estado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A38TrTareaComentarios_FechaCreacion) || ( A38TrTareaComentarios_FechaCreacion >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Field Tr Tarea Comentarios_Fecha Creacion is out of range", "OutOfRange", 1, "TRTAREACOMENTARIOS_FECHACREACION");
            AnyError = 1;
            GX_FocusControl = edtTrTareaComentarios_FechaCreacion_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A39TrTareaComentarios_FechaModificacion) || ( A39TrTareaComentarios_FechaModificacion >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Field Tr Tarea Comentarios_Fecha Modificacion is out of range", "OutOfRange", 1, "TRTAREACOMENTARIOS_FECHAMODIFICACION");
            AnyError = 1;
            GX_FocusControl = edtTrTareaComentarios_FechaModificacion_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors055( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_5( long A34TrTareaComentarios_IDTarea )
      {
         /* Using cursor T00056 */
         pr_default.execute(4, new Object[] {n34TrTareaComentarios_IDTarea, A34TrTareaComentarios_IDTarea});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A34TrTareaComentarios_IDTarea) ) )
            {
               GX_msglist.addItem("No matching 'Tr Gestion Tareas2_STG'.", "ForeignKeyNotFound", 1, "TRTAREACOMENTARIOS_IDTAREA");
               AnyError = 1;
               GX_FocusControl = edtTrTareaComentarios_IDTarea_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey055( )
      {
         /* Using cursor T00057 */
         pr_default.execute(5, new Object[] {A35TrTareaComentarios_ID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound5 = 1;
         }
         else
         {
            RcdFound5 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00053 */
         pr_default.execute(1, new Object[] {A35TrTareaComentarios_ID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM055( 4) ;
            RcdFound5 = 1;
            A35TrTareaComentarios_ID = T00053_A35TrTareaComentarios_ID[0];
            AssignAttri("", false, "A35TrTareaComentarios_ID", StringUtil.LTrimStr( (decimal)(A35TrTareaComentarios_ID), 13, 0));
            A36TrTareaComentarios_Descripcion = T00053_A36TrTareaComentarios_Descripcion[0];
            n36TrTareaComentarios_Descripcion = T00053_n36TrTareaComentarios_Descripcion[0];
            AssignAttri("", false, "A36TrTareaComentarios_Descripcion", A36TrTareaComentarios_Descripcion);
            A37TrTareaComentarios_Estado = T00053_A37TrTareaComentarios_Estado[0];
            n37TrTareaComentarios_Estado = T00053_n37TrTareaComentarios_Estado[0];
            AssignAttri("", false, "A37TrTareaComentarios_Estado", StringUtil.LTrimStr( (decimal)(A37TrTareaComentarios_Estado), 4, 0));
            A38TrTareaComentarios_FechaCreacion = T00053_A38TrTareaComentarios_FechaCreacion[0];
            n38TrTareaComentarios_FechaCreacion = T00053_n38TrTareaComentarios_FechaCreacion[0];
            AssignAttri("", false, "A38TrTareaComentarios_FechaCreacion", context.localUtil.Format(A38TrTareaComentarios_FechaCreacion, "99/99/9999"));
            A39TrTareaComentarios_FechaModificacion = T00053_A39TrTareaComentarios_FechaModificacion[0];
            n39TrTareaComentarios_FechaModificacion = T00053_n39TrTareaComentarios_FechaModificacion[0];
            AssignAttri("", false, "A39TrTareaComentarios_FechaModificacion", context.localUtil.Format(A39TrTareaComentarios_FechaModificacion, "99/99/9999"));
            A34TrTareaComentarios_IDTarea = T00053_A34TrTareaComentarios_IDTarea[0];
            n34TrTareaComentarios_IDTarea = T00053_n34TrTareaComentarios_IDTarea[0];
            AssignAttri("", false, "A34TrTareaComentarios_IDTarea", StringUtil.LTrimStr( (decimal)(A34TrTareaComentarios_IDTarea), 13, 0));
            Z35TrTareaComentarios_ID = A35TrTareaComentarios_ID;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load055( ) ;
            if ( AnyError == 1 )
            {
               RcdFound5 = 0;
               InitializeNonKey055( ) ;
            }
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound5 = 0;
            InitializeNonKey055( ) ;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey055( ) ;
         if ( RcdFound5 == 0 )
         {
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound5 = 0;
         /* Using cursor T00058 */
         pr_default.execute(6, new Object[] {A35TrTareaComentarios_ID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00058_A35TrTareaComentarios_ID[0] < A35TrTareaComentarios_ID ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00058_A35TrTareaComentarios_ID[0] > A35TrTareaComentarios_ID ) ) )
            {
               A35TrTareaComentarios_ID = T00058_A35TrTareaComentarios_ID[0];
               AssignAttri("", false, "A35TrTareaComentarios_ID", StringUtil.LTrimStr( (decimal)(A35TrTareaComentarios_ID), 13, 0));
               RcdFound5 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound5 = 0;
         /* Using cursor T00059 */
         pr_default.execute(7, new Object[] {A35TrTareaComentarios_ID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00059_A35TrTareaComentarios_ID[0] > A35TrTareaComentarios_ID ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00059_A35TrTareaComentarios_ID[0] < A35TrTareaComentarios_ID ) ) )
            {
               A35TrTareaComentarios_ID = T00059_A35TrTareaComentarios_ID[0];
               AssignAttri("", false, "A35TrTareaComentarios_ID", StringUtil.LTrimStr( (decimal)(A35TrTareaComentarios_ID), 13, 0));
               RcdFound5 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey055( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTrTareaComentarios_ID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert055( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound5 == 1 )
            {
               if ( A35TrTareaComentarios_ID != Z35TrTareaComentarios_ID )
               {
                  A35TrTareaComentarios_ID = Z35TrTareaComentarios_ID;
                  AssignAttri("", false, "A35TrTareaComentarios_ID", StringUtil.LTrimStr( (decimal)(A35TrTareaComentarios_ID), 13, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TRTAREACOMENTARIOS_ID");
                  AnyError = 1;
                  GX_FocusControl = edtTrTareaComentarios_ID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTrTareaComentarios_ID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update055( ) ;
                  GX_FocusControl = edtTrTareaComentarios_ID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A35TrTareaComentarios_ID != Z35TrTareaComentarios_ID )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTrTareaComentarios_ID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert055( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TRTAREACOMENTARIOS_ID");
                     AnyError = 1;
                     GX_FocusControl = edtTrTareaComentarios_ID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtTrTareaComentarios_ID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert055( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      protected void btn_delete( )
      {
         if ( A35TrTareaComentarios_ID != Z35TrTareaComentarios_ID )
         {
            A35TrTareaComentarios_ID = Z35TrTareaComentarios_ID;
            AssignAttri("", false, "A35TrTareaComentarios_ID", StringUtil.LTrimStr( (decimal)(A35TrTareaComentarios_ID), 13, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TRTAREACOMENTARIOS_ID");
            AnyError = 1;
            GX_FocusControl = edtTrTareaComentarios_ID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTrTareaComentarios_ID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            getByPrimaryKey( ) ;
         }
         CloseOpenCursors();
      }

      protected void btn_get( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TRTAREACOMENTARIOS_ID");
            AnyError = 1;
            GX_FocusControl = edtTrTareaComentarios_ID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtTrTareaComentarios_IDTarea_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart055( ) ;
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTrTareaComentarios_IDTarea_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd055( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_previous( ) ;
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTrTareaComentarios_IDTarea_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_next( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_next( ) ;
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTrTareaComentarios_IDTarea_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart055( ) ;
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound5 != 0 )
            {
               ScanNext055( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTrTareaComentarios_IDTarea_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd055( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency055( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00052 */
            pr_default.execute(0, new Object[] {A35TrTareaComentarios_ID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TrTareaComentarios"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z37TrTareaComentarios_Estado != T00052_A37TrTareaComentarios_Estado[0] ) || ( Z38TrTareaComentarios_FechaCreacion != T00052_A38TrTareaComentarios_FechaCreacion[0] ) || ( Z39TrTareaComentarios_FechaModificacion != T00052_A39TrTareaComentarios_FechaModificacion[0] ) || ( Z34TrTareaComentarios_IDTarea != T00052_A34TrTareaComentarios_IDTarea[0] ) )
            {
               if ( Z37TrTareaComentarios_Estado != T00052_A37TrTareaComentarios_Estado[0] )
               {
                  GXUtil.WriteLog("trtareacomentarios:[seudo value changed for attri]"+"TrTareaComentarios_Estado");
                  GXUtil.WriteLogRaw("Old: ",Z37TrTareaComentarios_Estado);
                  GXUtil.WriteLogRaw("Current: ",T00052_A37TrTareaComentarios_Estado[0]);
               }
               if ( Z38TrTareaComentarios_FechaCreacion != T00052_A38TrTareaComentarios_FechaCreacion[0] )
               {
                  GXUtil.WriteLog("trtareacomentarios:[seudo value changed for attri]"+"TrTareaComentarios_FechaCreacion");
                  GXUtil.WriteLogRaw("Old: ",Z38TrTareaComentarios_FechaCreacion);
                  GXUtil.WriteLogRaw("Current: ",T00052_A38TrTareaComentarios_FechaCreacion[0]);
               }
               if ( Z39TrTareaComentarios_FechaModificacion != T00052_A39TrTareaComentarios_FechaModificacion[0] )
               {
                  GXUtil.WriteLog("trtareacomentarios:[seudo value changed for attri]"+"TrTareaComentarios_FechaModificacion");
                  GXUtil.WriteLogRaw("Old: ",Z39TrTareaComentarios_FechaModificacion);
                  GXUtil.WriteLogRaw("Current: ",T00052_A39TrTareaComentarios_FechaModificacion[0]);
               }
               if ( Z34TrTareaComentarios_IDTarea != T00052_A34TrTareaComentarios_IDTarea[0] )
               {
                  GXUtil.WriteLog("trtareacomentarios:[seudo value changed for attri]"+"TrTareaComentarios_IDTarea");
                  GXUtil.WriteLogRaw("Old: ",Z34TrTareaComentarios_IDTarea);
                  GXUtil.WriteLogRaw("Current: ",T00052_A34TrTareaComentarios_IDTarea[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TrTareaComentarios"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert055( )
      {
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable055( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM055( 0) ;
            CheckOptimisticConcurrency055( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm055( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert055( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000510 */
                     pr_default.execute(8, new Object[] {n36TrTareaComentarios_Descripcion, A36TrTareaComentarios_Descripcion, n37TrTareaComentarios_Estado, A37TrTareaComentarios_Estado, n38TrTareaComentarios_FechaCreacion, A38TrTareaComentarios_FechaCreacion, n39TrTareaComentarios_FechaModificacion, A39TrTareaComentarios_FechaModificacion, n34TrTareaComentarios_IDTarea, A34TrTareaComentarios_IDTarea});
                     A35TrTareaComentarios_ID = T000510_A35TrTareaComentarios_ID[0];
                     AssignAttri("", false, "A35TrTareaComentarios_ID", StringUtil.LTrimStr( (decimal)(A35TrTareaComentarios_ID), 13, 0));
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("TrTareaComentarios") ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           GX_msglist.addItem(context.GetMessage( "GXM_sucadded", ""), "SuccessfullyAdded", 0, "", true);
                           ResetCaption050( ) ;
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load055( ) ;
            }
            EndLevel055( ) ;
         }
         CloseExtendedTableCursors055( ) ;
      }

      protected void Update055( )
      {
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable055( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency055( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm055( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate055( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000511 */
                     pr_default.execute(9, new Object[] {n36TrTareaComentarios_Descripcion, A36TrTareaComentarios_Descripcion, n37TrTareaComentarios_Estado, A37TrTareaComentarios_Estado, n38TrTareaComentarios_FechaCreacion, A38TrTareaComentarios_FechaCreacion, n39TrTareaComentarios_FechaModificacion, A39TrTareaComentarios_FechaModificacion, n34TrTareaComentarios_IDTarea, A34TrTareaComentarios_IDTarea, A35TrTareaComentarios_ID});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("TrTareaComentarios") ;
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TrTareaComentarios"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate055( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           GX_msglist.addItem(context.GetMessage( "GXM_sucupdated", ""), "SuccessfullyUpdated", 0, "", true);
                           ResetCaption050( ) ;
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel055( ) ;
         }
         CloseExtendedTableCursors055( ) ;
      }

      protected void DeferredUpdate055( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency055( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls055( ) ;
            AfterConfirm055( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete055( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000512 */
                  pr_default.execute(10, new Object[] {A35TrTareaComentarios_ID});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("TrTareaComentarios") ;
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound5 == 0 )
                        {
                           InitAll055( ) ;
                           Gx_mode = "INS";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        else
                        {
                           getByPrimaryKey( ) ;
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        GX_msglist.addItem(context.GetMessage( "GXM_sucdeleted", ""), "SuccessfullyDeleted", 0, "", true);
                        ResetCaption050( ) ;
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode5 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel055( ) ;
         Gx_mode = sMode5;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls055( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel055( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete055( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("trtareacomentarios",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues050( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("trtareacomentarios",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart055( )
      {
         /* Using cursor T000513 */
         pr_default.execute(11);
         RcdFound5 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound5 = 1;
            A35TrTareaComentarios_ID = T000513_A35TrTareaComentarios_ID[0];
            AssignAttri("", false, "A35TrTareaComentarios_ID", StringUtil.LTrimStr( (decimal)(A35TrTareaComentarios_ID), 13, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext055( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound5 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound5 = 1;
            A35TrTareaComentarios_ID = T000513_A35TrTareaComentarios_ID[0];
            AssignAttri("", false, "A35TrTareaComentarios_ID", StringUtil.LTrimStr( (decimal)(A35TrTareaComentarios_ID), 13, 0));
         }
      }

      protected void ScanEnd055( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm055( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert055( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate055( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete055( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete055( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate055( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes055( )
      {
         edtTrTareaComentarios_ID_Enabled = 0;
         AssignProp("", false, edtTrTareaComentarios_ID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrTareaComentarios_ID_Enabled), 5, 0), true);
         edtTrTareaComentarios_IDTarea_Enabled = 0;
         AssignProp("", false, edtTrTareaComentarios_IDTarea_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrTareaComentarios_IDTarea_Enabled), 5, 0), true);
         edtTrTareaComentarios_Descripcion_Enabled = 0;
         AssignProp("", false, edtTrTareaComentarios_Descripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrTareaComentarios_Descripcion_Enabled), 5, 0), true);
         cmbTrTareaComentarios_Estado.Enabled = 0;
         AssignProp("", false, cmbTrTareaComentarios_Estado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbTrTareaComentarios_Estado.Enabled), 5, 0), true);
         edtTrTareaComentarios_FechaCreacion_Enabled = 0;
         AssignProp("", false, edtTrTareaComentarios_FechaCreacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrTareaComentarios_FechaCreacion_Enabled), 5, 0), true);
         edtTrTareaComentarios_FechaModificacion_Enabled = 0;
         AssignProp("", false, edtTrTareaComentarios_FechaModificacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTrTareaComentarios_FechaModificacion_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes055( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues050( )
      {
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         MasterPageObj.master_styles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 947160), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("gxcfg.js", "?202210202136453", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("calendar-en.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         bodyStyle = bodyStyle + "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle = bodyStyle + " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trtareacomentarios.aspx") +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z35TrTareaComentarios_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z35TrTareaComentarios_ID), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z37TrTareaComentarios_Estado", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z37TrTareaComentarios_Estado), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z38TrTareaComentarios_FechaCreacion", context.localUtil.DToC( Z38TrTareaComentarios_FechaCreacion, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z39TrTareaComentarios_FechaModificacion", context.localUtil.DToC( Z39TrTareaComentarios_FechaModificacion, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z34TrTareaComentarios_IDTarea", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z34TrTareaComentarios_IDTarea), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override String GetSelfLink( )
      {
         return formatLink("trtareacomentarios.aspx")  ;
      }

      public override String GetPgmname( )
      {
         return "TrTareaComentarios" ;
      }

      public override String GetPgmdesc( )
      {
         return "Tr Tarea Comentarios" ;
      }

      protected void InitializeNonKey055( )
      {
         A34TrTareaComentarios_IDTarea = 0;
         n34TrTareaComentarios_IDTarea = false;
         AssignAttri("", false, "A34TrTareaComentarios_IDTarea", StringUtil.LTrimStr( (decimal)(A34TrTareaComentarios_IDTarea), 13, 0));
         n34TrTareaComentarios_IDTarea = ((0==A34TrTareaComentarios_IDTarea) ? true : false);
         A36TrTareaComentarios_Descripcion = "";
         n36TrTareaComentarios_Descripcion = false;
         AssignAttri("", false, "A36TrTareaComentarios_Descripcion", A36TrTareaComentarios_Descripcion);
         n36TrTareaComentarios_Descripcion = (String.IsNullOrEmpty(StringUtil.RTrim( A36TrTareaComentarios_Descripcion)) ? true : false);
         A37TrTareaComentarios_Estado = 0;
         n37TrTareaComentarios_Estado = false;
         AssignAttri("", false, "A37TrTareaComentarios_Estado", StringUtil.LTrimStr( (decimal)(A37TrTareaComentarios_Estado), 4, 0));
         n37TrTareaComentarios_Estado = ((0==A37TrTareaComentarios_Estado) ? true : false);
         A38TrTareaComentarios_FechaCreacion = DateTime.MinValue;
         n38TrTareaComentarios_FechaCreacion = false;
         AssignAttri("", false, "A38TrTareaComentarios_FechaCreacion", context.localUtil.Format(A38TrTareaComentarios_FechaCreacion, "99/99/9999"));
         n38TrTareaComentarios_FechaCreacion = ((DateTime.MinValue==A38TrTareaComentarios_FechaCreacion) ? true : false);
         A39TrTareaComentarios_FechaModificacion = DateTime.MinValue;
         n39TrTareaComentarios_FechaModificacion = false;
         AssignAttri("", false, "A39TrTareaComentarios_FechaModificacion", context.localUtil.Format(A39TrTareaComentarios_FechaModificacion, "99/99/9999"));
         n39TrTareaComentarios_FechaModificacion = ((DateTime.MinValue==A39TrTareaComentarios_FechaModificacion) ? true : false);
         Z37TrTareaComentarios_Estado = 0;
         Z38TrTareaComentarios_FechaCreacion = DateTime.MinValue;
         Z39TrTareaComentarios_FechaModificacion = DateTime.MinValue;
         Z34TrTareaComentarios_IDTarea = 0;
      }

      protected void InitAll055( )
      {
         A35TrTareaComentarios_ID = 0;
         AssignAttri("", false, "A35TrTareaComentarios_ID", StringUtil.LTrimStr( (decimal)(A35TrTareaComentarios_ID), 13, 0));
         InitializeNonKey055( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( ) ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?202210202136456", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.eng.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("trtareacomentarios.js", "?202210202136456", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         edtTrTareaComentarios_ID_Internalname = "TRTAREACOMENTARIOS_ID";
         edtTrTareaComentarios_IDTarea_Internalname = "TRTAREACOMENTARIOS_IDTAREA";
         edtTrTareaComentarios_Descripcion_Internalname = "TRTAREACOMENTARIOS_DESCRIPCION";
         cmbTrTareaComentarios_Estado_Internalname = "TRTAREACOMENTARIOS_ESTADO";
         edtTrTareaComentarios_FechaCreacion_Internalname = "TRTAREACOMENTARIOS_FECHACREACION";
         edtTrTareaComentarios_FechaModificacion_Internalname = "TRTAREACOMENTARIOS_FECHAMODIFICACION";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         Form.Internalname = "FORM";
         imgprompt_34_Internalname = "PROMPT_34";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("K2BOrion");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Tr Tarea Comentarios";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtTrTareaComentarios_FechaModificacion_Jsonclick = "";
         edtTrTareaComentarios_FechaModificacion_Enabled = 1;
         edtTrTareaComentarios_FechaCreacion_Jsonclick = "";
         edtTrTareaComentarios_FechaCreacion_Enabled = 1;
         cmbTrTareaComentarios_Estado_Jsonclick = "";
         cmbTrTareaComentarios_Estado.Enabled = 1;
         edtTrTareaComentarios_Descripcion_Enabled = 1;
         imgprompt_34_Visible = 1;
         imgprompt_34_Link = "";
         edtTrTareaComentarios_IDTarea_Jsonclick = "";
         edtTrTareaComentarios_IDTarea_Enabled = 1;
         edtTrTareaComentarios_ID_Jsonclick = "";
         edtTrTareaComentarios_ID_Enabled = 1;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void init_web_controls( )
      {
         cmbTrTareaComentarios_Estado.Name = "TRTAREACOMENTARIOS_ESTADO";
         cmbTrTareaComentarios_Estado.WebTags = "";
         cmbTrTareaComentarios_Estado.addItem("1", "Activo", 0);
         cmbTrTareaComentarios_Estado.addItem("2", "Inactivo", 0);
         cmbTrTareaComentarios_Estado.addItem("3", "Eliminado", 0);
         if ( cmbTrTareaComentarios_Estado.ItemCount > 0 )
         {
            A37TrTareaComentarios_Estado = (short)(NumberUtil.Val( cmbTrTareaComentarios_Estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A37TrTareaComentarios_Estado), 4, 0))), "."));
            n37TrTareaComentarios_Estado = false;
            AssignAttri("", false, "A37TrTareaComentarios_Estado", StringUtil.LTrimStr( (decimal)(A37TrTareaComentarios_Estado), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtTrTareaComentarios_IDTarea_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void Valid_Trtareacomentarios_id( )
      {
         n37TrTareaComentarios_Estado = false;
         A37TrTareaComentarios_Estado = (short)(NumberUtil.Val( cmbTrTareaComentarios_Estado.CurrentValue, "."));
         n37TrTareaComentarios_Estado = false;
         cmbTrTareaComentarios_Estado.CurrentValue = StringUtil.LTrimStr( (decimal)(A37TrTareaComentarios_Estado), 4, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbTrTareaComentarios_Estado.ItemCount > 0 )
         {
            A37TrTareaComentarios_Estado = (short)(NumberUtil.Val( cmbTrTareaComentarios_Estado.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A37TrTareaComentarios_Estado), 4, 0))), "."));
            n37TrTareaComentarios_Estado = false;
            cmbTrTareaComentarios_Estado.CurrentValue = StringUtil.LTrimStr( (decimal)(A37TrTareaComentarios_Estado), 4, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTrTareaComentarios_Estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A37TrTareaComentarios_Estado), 4, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A34TrTareaComentarios_IDTarea", StringUtil.LTrim( StringUtil.NToC( (decimal)(A34TrTareaComentarios_IDTarea), 13, 0, ".", "")));
         AssignAttri("", false, "A36TrTareaComentarios_Descripcion", A36TrTareaComentarios_Descripcion);
         AssignAttri("", false, "A37TrTareaComentarios_Estado", StringUtil.LTrim( StringUtil.NToC( (decimal)(A37TrTareaComentarios_Estado), 4, 0, ".", "")));
         cmbTrTareaComentarios_Estado.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A37TrTareaComentarios_Estado), 4, 0));
         AssignProp("", false, cmbTrTareaComentarios_Estado_Internalname, "Values", cmbTrTareaComentarios_Estado.ToJavascriptSource(), true);
         AssignAttri("", false, "A38TrTareaComentarios_FechaCreacion", context.localUtil.Format(A38TrTareaComentarios_FechaCreacion, "99/99/9999"));
         AssignAttri("", false, "A39TrTareaComentarios_FechaModificacion", context.localUtil.Format(A39TrTareaComentarios_FechaModificacion, "99/99/9999"));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z35TrTareaComentarios_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z35TrTareaComentarios_ID), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z34TrTareaComentarios_IDTarea", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z34TrTareaComentarios_IDTarea), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z36TrTareaComentarios_Descripcion", Z36TrTareaComentarios_Descripcion);
         GxWebStd.gx_hidden_field( context, "Z37TrTareaComentarios_Estado", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z37TrTareaComentarios_Estado), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z38TrTareaComentarios_FechaCreacion", context.localUtil.Format(Z38TrTareaComentarios_FechaCreacion, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "Z39TrTareaComentarios_FechaModificacion", context.localUtil.Format(Z39TrTareaComentarios_FechaModificacion, "99/99/9999"));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Trtareacomentarios_idtarea( )
      {
         n34TrTareaComentarios_IDTarea = false;
         /* Using cursor T000514 */
         pr_default.execute(12, new Object[] {n34TrTareaComentarios_IDTarea, A34TrTareaComentarios_IDTarea});
         if ( (pr_default.getStatus(12) == 101) )
         {
            if ( ! ( (0==A34TrTareaComentarios_IDTarea) ) )
            {
               GX_msglist.addItem("No matching 'Tr Gestion Tareas2_STG'.", "ForeignKeyNotFound", 1, "TRTAREACOMENTARIOS_IDTAREA");
               AnyError = 1;
               GX_FocusControl = edtTrTareaComentarios_IDTarea_Internalname;
            }
         }
         pr_default.close(12);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_TRTAREACOMENTARIOS_ID","{handler:'Valid_Trtareacomentarios_id',iparms:[{av:'cmbTrTareaComentarios_Estado'},{av:'A37TrTareaComentarios_Estado',fld:'TRTAREACOMENTARIOS_ESTADO',pic:'ZZZ9'},{av:'A35TrTareaComentarios_ID',fld:'TRTAREACOMENTARIOS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_TRTAREACOMENTARIOS_ID",",oparms:[{av:'A34TrTareaComentarios_IDTarea',fld:'TRTAREACOMENTARIOS_IDTAREA',pic:'ZZZZZZZZZZZZ9'},{av:'A36TrTareaComentarios_Descripcion',fld:'TRTAREACOMENTARIOS_DESCRIPCION',pic:''},{av:'cmbTrTareaComentarios_Estado'},{av:'A37TrTareaComentarios_Estado',fld:'TRTAREACOMENTARIOS_ESTADO',pic:'ZZZ9'},{av:'A38TrTareaComentarios_FechaCreacion',fld:'TRTAREACOMENTARIOS_FECHACREACION',pic:''},{av:'A39TrTareaComentarios_FechaModificacion',fld:'TRTAREACOMENTARIOS_FECHAMODIFICACION',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z35TrTareaComentarios_ID'},{av:'Z34TrTareaComentarios_IDTarea'},{av:'Z36TrTareaComentarios_Descripcion'},{av:'Z37TrTareaComentarios_Estado'},{av:'Z38TrTareaComentarios_FechaCreacion'},{av:'Z39TrTareaComentarios_FechaModificacion'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_TRTAREACOMENTARIOS_IDTAREA","{handler:'Valid_Trtareacomentarios_idtarea',iparms:[{av:'A34TrTareaComentarios_IDTarea',fld:'TRTAREACOMENTARIOS_IDTAREA',pic:'ZZZZZZZZZZZZ9'}]");
         setEventMetadata("VALID_TRTAREACOMENTARIOS_IDTAREA",",oparms:[]}");
         setEventMetadata("VALID_TRTAREACOMENTARIOS_ESTADO","{handler:'Valid_Trtareacomentarios_estado',iparms:[]");
         setEventMetadata("VALID_TRTAREACOMENTARIOS_ESTADO",",oparms:[]}");
         setEventMetadata("VALID_TRTAREACOMENTARIOS_FECHACREACION","{handler:'Valid_Trtareacomentarios_fechacreacion',iparms:[]");
         setEventMetadata("VALID_TRTAREACOMENTARIOS_FECHACREACION",",oparms:[]}");
         setEventMetadata("VALID_TRTAREACOMENTARIOS_FECHAMODIFICACION","{handler:'Valid_Trtareacomentarios_fechamodificacion',iparms:[]");
         setEventMetadata("VALID_TRTAREACOMENTARIOS_FECHAMODIFICACION",",oparms:[]}");
         return  ;
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections() ;
         }
      }

      protected void CloseOpenCursors( )
      {
         pr_default.close(1);
         pr_default.close(12);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z38TrTareaComentarios_FechaCreacion = DateTime.MinValue;
         Z39TrTareaComentarios_FechaModificacion = DateTime.MinValue;
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         sImgUrl = "";
         A36TrTareaComentarios_Descripcion = "";
         A38TrTareaComentarios_FechaCreacion = DateTime.MinValue;
         A39TrTareaComentarios_FechaModificacion = DateTime.MinValue;
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         Z36TrTareaComentarios_Descripcion = "";
         T00055_A35TrTareaComentarios_ID = new long[1] ;
         T00055_A36TrTareaComentarios_Descripcion = new String[] {""} ;
         T00055_n36TrTareaComentarios_Descripcion = new bool[] {false} ;
         T00055_A37TrTareaComentarios_Estado = new short[1] ;
         T00055_n37TrTareaComentarios_Estado = new bool[] {false} ;
         T00055_A38TrTareaComentarios_FechaCreacion = new DateTime[] {DateTime.MinValue} ;
         T00055_n38TrTareaComentarios_FechaCreacion = new bool[] {false} ;
         T00055_A39TrTareaComentarios_FechaModificacion = new DateTime[] {DateTime.MinValue} ;
         T00055_n39TrTareaComentarios_FechaModificacion = new bool[] {false} ;
         T00055_A34TrTareaComentarios_IDTarea = new long[1] ;
         T00055_n34TrTareaComentarios_IDTarea = new bool[] {false} ;
         T00054_A34TrTareaComentarios_IDTarea = new long[1] ;
         T00054_n34TrTareaComentarios_IDTarea = new bool[] {false} ;
         T00056_A34TrTareaComentarios_IDTarea = new long[1] ;
         T00056_n34TrTareaComentarios_IDTarea = new bool[] {false} ;
         T00057_A35TrTareaComentarios_ID = new long[1] ;
         T00053_A35TrTareaComentarios_ID = new long[1] ;
         T00053_A36TrTareaComentarios_Descripcion = new String[] {""} ;
         T00053_n36TrTareaComentarios_Descripcion = new bool[] {false} ;
         T00053_A37TrTareaComentarios_Estado = new short[1] ;
         T00053_n37TrTareaComentarios_Estado = new bool[] {false} ;
         T00053_A38TrTareaComentarios_FechaCreacion = new DateTime[] {DateTime.MinValue} ;
         T00053_n38TrTareaComentarios_FechaCreacion = new bool[] {false} ;
         T00053_A39TrTareaComentarios_FechaModificacion = new DateTime[] {DateTime.MinValue} ;
         T00053_n39TrTareaComentarios_FechaModificacion = new bool[] {false} ;
         T00053_A34TrTareaComentarios_IDTarea = new long[1] ;
         T00053_n34TrTareaComentarios_IDTarea = new bool[] {false} ;
         sMode5 = "";
         T00058_A35TrTareaComentarios_ID = new long[1] ;
         T00059_A35TrTareaComentarios_ID = new long[1] ;
         T00052_A35TrTareaComentarios_ID = new long[1] ;
         T00052_A36TrTareaComentarios_Descripcion = new String[] {""} ;
         T00052_n36TrTareaComentarios_Descripcion = new bool[] {false} ;
         T00052_A37TrTareaComentarios_Estado = new short[1] ;
         T00052_n37TrTareaComentarios_Estado = new bool[] {false} ;
         T00052_A38TrTareaComentarios_FechaCreacion = new DateTime[] {DateTime.MinValue} ;
         T00052_n38TrTareaComentarios_FechaCreacion = new bool[] {false} ;
         T00052_A39TrTareaComentarios_FechaModificacion = new DateTime[] {DateTime.MinValue} ;
         T00052_n39TrTareaComentarios_FechaModificacion = new bool[] {false} ;
         T00052_A34TrTareaComentarios_IDTarea = new long[1] ;
         T00052_n34TrTareaComentarios_IDTarea = new bool[] {false} ;
         T000510_A35TrTareaComentarios_ID = new long[1] ;
         T000513_A35TrTareaComentarios_ID = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ36TrTareaComentarios_Descripcion = "";
         ZZ38TrTareaComentarios_FechaCreacion = DateTime.MinValue;
         ZZ39TrTareaComentarios_FechaModificacion = DateTime.MinValue;
         T000514_A34TrTareaComentarios_IDTarea = new long[1] ;
         T000514_n34TrTareaComentarios_IDTarea = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trtareacomentarios__default(),
            new Object[][] {
                new Object[] {
               T00052_A35TrTareaComentarios_ID, T00052_A36TrTareaComentarios_Descripcion, T00052_n36TrTareaComentarios_Descripcion, T00052_A37TrTareaComentarios_Estado, T00052_n37TrTareaComentarios_Estado, T00052_A38TrTareaComentarios_FechaCreacion, T00052_n38TrTareaComentarios_FechaCreacion, T00052_A39TrTareaComentarios_FechaModificacion, T00052_n39TrTareaComentarios_FechaModificacion, T00052_A34TrTareaComentarios_IDTarea,
               T00052_n34TrTareaComentarios_IDTarea
               }
               , new Object[] {
               T00053_A35TrTareaComentarios_ID, T00053_A36TrTareaComentarios_Descripcion, T00053_n36TrTareaComentarios_Descripcion, T00053_A37TrTareaComentarios_Estado, T00053_n37TrTareaComentarios_Estado, T00053_A38TrTareaComentarios_FechaCreacion, T00053_n38TrTareaComentarios_FechaCreacion, T00053_A39TrTareaComentarios_FechaModificacion, T00053_n39TrTareaComentarios_FechaModificacion, T00053_A34TrTareaComentarios_IDTarea,
               T00053_n34TrTareaComentarios_IDTarea
               }
               , new Object[] {
               T00054_A34TrTareaComentarios_IDTarea
               }
               , new Object[] {
               T00055_A35TrTareaComentarios_ID, T00055_A36TrTareaComentarios_Descripcion, T00055_n36TrTareaComentarios_Descripcion, T00055_A37TrTareaComentarios_Estado, T00055_n37TrTareaComentarios_Estado, T00055_A38TrTareaComentarios_FechaCreacion, T00055_n38TrTareaComentarios_FechaCreacion, T00055_A39TrTareaComentarios_FechaModificacion, T00055_n39TrTareaComentarios_FechaModificacion, T00055_A34TrTareaComentarios_IDTarea,
               T00055_n34TrTareaComentarios_IDTarea
               }
               , new Object[] {
               T00056_A34TrTareaComentarios_IDTarea
               }
               , new Object[] {
               T00057_A35TrTareaComentarios_ID
               }
               , new Object[] {
               T00058_A35TrTareaComentarios_ID
               }
               , new Object[] {
               T00059_A35TrTareaComentarios_ID
               }
               , new Object[] {
               T000510_A35TrTareaComentarios_ID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000513_A35TrTareaComentarios_ID
               }
               , new Object[] {
               T000514_A34TrTareaComentarios_IDTarea
               }
            }
         );
      }

      private short Z37TrTareaComentarios_Estado ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A37TrTareaComentarios_Estado ;
      private short GX_JID ;
      private short RcdFound5 ;
      private short nIsDirty_5 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ37TrTareaComentarios_Estado ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtTrTareaComentarios_ID_Enabled ;
      private int edtTrTareaComentarios_IDTarea_Enabled ;
      private int imgprompt_34_Visible ;
      private int edtTrTareaComentarios_Descripcion_Enabled ;
      private int edtTrTareaComentarios_FechaCreacion_Enabled ;
      private int edtTrTareaComentarios_FechaModificacion_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z35TrTareaComentarios_ID ;
      private long Z34TrTareaComentarios_IDTarea ;
      private long A34TrTareaComentarios_IDTarea ;
      private long A35TrTareaComentarios_ID ;
      private long ZZ35TrTareaComentarios_ID ;
      private long ZZ34TrTareaComentarios_IDTarea ;
      private String sPrefix ;
      private String scmdbuf ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String GXKey ;
      private String PreviousTooltip ;
      private String PreviousCaption ;
      private String GX_FocusControl ;
      private String edtTrTareaComentarios_ID_Internalname ;
      private String cmbTrTareaComentarios_Estado_Internalname ;
      private String divTablemain_Internalname ;
      private String lblTitle_Internalname ;
      private String lblTitle_Jsonclick ;
      private String TempTags ;
      private String ClassString ;
      private String StyleString ;
      private String bttBtn_first_Internalname ;
      private String bttBtn_first_Jsonclick ;
      private String bttBtn_previous_Internalname ;
      private String bttBtn_previous_Jsonclick ;
      private String bttBtn_next_Internalname ;
      private String bttBtn_next_Jsonclick ;
      private String bttBtn_last_Internalname ;
      private String bttBtn_last_Jsonclick ;
      private String bttBtn_select_Internalname ;
      private String bttBtn_select_Jsonclick ;
      private String edtTrTareaComentarios_ID_Jsonclick ;
      private String edtTrTareaComentarios_IDTarea_Internalname ;
      private String edtTrTareaComentarios_IDTarea_Jsonclick ;
      private String sImgUrl ;
      private String imgprompt_34_Internalname ;
      private String imgprompt_34_Link ;
      private String edtTrTareaComentarios_Descripcion_Internalname ;
      private String cmbTrTareaComentarios_Estado_Jsonclick ;
      private String edtTrTareaComentarios_FechaCreacion_Internalname ;
      private String edtTrTareaComentarios_FechaCreacion_Jsonclick ;
      private String edtTrTareaComentarios_FechaModificacion_Internalname ;
      private String edtTrTareaComentarios_FechaModificacion_Jsonclick ;
      private String bttBtn_enter_Internalname ;
      private String bttBtn_enter_Jsonclick ;
      private String bttBtn_cancel_Internalname ;
      private String bttBtn_cancel_Jsonclick ;
      private String bttBtn_delete_Internalname ;
      private String bttBtn_delete_Jsonclick ;
      private String Gx_mode ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String sMode5 ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private DateTime Z38TrTareaComentarios_FechaCreacion ;
      private DateTime Z39TrTareaComentarios_FechaModificacion ;
      private DateTime A38TrTareaComentarios_FechaCreacion ;
      private DateTime A39TrTareaComentarios_FechaModificacion ;
      private DateTime ZZ38TrTareaComentarios_FechaCreacion ;
      private DateTime ZZ39TrTareaComentarios_FechaModificacion ;
      private bool entryPointCalled ;
      private bool n34TrTareaComentarios_IDTarea ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n37TrTareaComentarios_Estado ;
      private bool n38TrTareaComentarios_FechaCreacion ;
      private bool n39TrTareaComentarios_FechaModificacion ;
      private bool n36TrTareaComentarios_Descripcion ;
      private String A36TrTareaComentarios_Descripcion ;
      private String Z36TrTareaComentarios_Descripcion ;
      private String ZZ36TrTareaComentarios_Descripcion ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbTrTareaComentarios_Estado ;
      private IDataStoreProvider pr_default ;
      private long[] T00055_A35TrTareaComentarios_ID ;
      private String[] T00055_A36TrTareaComentarios_Descripcion ;
      private bool[] T00055_n36TrTareaComentarios_Descripcion ;
      private short[] T00055_A37TrTareaComentarios_Estado ;
      private bool[] T00055_n37TrTareaComentarios_Estado ;
      private DateTime[] T00055_A38TrTareaComentarios_FechaCreacion ;
      private bool[] T00055_n38TrTareaComentarios_FechaCreacion ;
      private DateTime[] T00055_A39TrTareaComentarios_FechaModificacion ;
      private bool[] T00055_n39TrTareaComentarios_FechaModificacion ;
      private long[] T00055_A34TrTareaComentarios_IDTarea ;
      private bool[] T00055_n34TrTareaComentarios_IDTarea ;
      private long[] T00054_A34TrTareaComentarios_IDTarea ;
      private bool[] T00054_n34TrTareaComentarios_IDTarea ;
      private long[] T00056_A34TrTareaComentarios_IDTarea ;
      private bool[] T00056_n34TrTareaComentarios_IDTarea ;
      private long[] T00057_A35TrTareaComentarios_ID ;
      private long[] T00053_A35TrTareaComentarios_ID ;
      private String[] T00053_A36TrTareaComentarios_Descripcion ;
      private bool[] T00053_n36TrTareaComentarios_Descripcion ;
      private short[] T00053_A37TrTareaComentarios_Estado ;
      private bool[] T00053_n37TrTareaComentarios_Estado ;
      private DateTime[] T00053_A38TrTareaComentarios_FechaCreacion ;
      private bool[] T00053_n38TrTareaComentarios_FechaCreacion ;
      private DateTime[] T00053_A39TrTareaComentarios_FechaModificacion ;
      private bool[] T00053_n39TrTareaComentarios_FechaModificacion ;
      private long[] T00053_A34TrTareaComentarios_IDTarea ;
      private bool[] T00053_n34TrTareaComentarios_IDTarea ;
      private long[] T00058_A35TrTareaComentarios_ID ;
      private long[] T00059_A35TrTareaComentarios_ID ;
      private long[] T00052_A35TrTareaComentarios_ID ;
      private String[] T00052_A36TrTareaComentarios_Descripcion ;
      private bool[] T00052_n36TrTareaComentarios_Descripcion ;
      private short[] T00052_A37TrTareaComentarios_Estado ;
      private bool[] T00052_n37TrTareaComentarios_Estado ;
      private DateTime[] T00052_A38TrTareaComentarios_FechaCreacion ;
      private bool[] T00052_n38TrTareaComentarios_FechaCreacion ;
      private DateTime[] T00052_A39TrTareaComentarios_FechaModificacion ;
      private bool[] T00052_n39TrTareaComentarios_FechaModificacion ;
      private long[] T00052_A34TrTareaComentarios_IDTarea ;
      private bool[] T00052_n34TrTareaComentarios_IDTarea ;
      private long[] T000510_A35TrTareaComentarios_ID ;
      private long[] T000513_A35TrTareaComentarios_ID ;
      private long[] T000514_A34TrTareaComentarios_IDTarea ;
      private bool[] T000514_n34TrTareaComentarios_IDTarea ;
      private GXWebForm Form ;
   }

   public class trtareacomentarios__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new UpdateCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00055 ;
          prmT00055 = new Object[] {
          new Object[] {"@TrTareaComentarios_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT00054 ;
          prmT00054 = new Object[] {
          new Object[] {"@TrTareaComentarios_IDTarea",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT00056 ;
          prmT00056 = new Object[] {
          new Object[] {"@TrTareaComentarios_IDTarea",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT00057 ;
          prmT00057 = new Object[] {
          new Object[] {"@TrTareaComentarios_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT00053 ;
          prmT00053 = new Object[] {
          new Object[] {"@TrTareaComentarios_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT00058 ;
          prmT00058 = new Object[] {
          new Object[] {"@TrTareaComentarios_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT00059 ;
          prmT00059 = new Object[] {
          new Object[] {"@TrTareaComentarios_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT00052 ;
          prmT00052 = new Object[] {
          new Object[] {"@TrTareaComentarios_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT000510 ;
          prmT000510 = new Object[] {
          new Object[] {"@TrTareaComentarios_Descripcion",SqlDbType.NVarChar,2097152,0} ,
          new Object[] {"@TrTareaComentarios_Estado",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@TrTareaComentarios_FechaCreacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrTareaComentarios_FechaModificacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrTareaComentarios_IDTarea",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT000511 ;
          prmT000511 = new Object[] {
          new Object[] {"@TrTareaComentarios_Descripcion",SqlDbType.NVarChar,2097152,0} ,
          new Object[] {"@TrTareaComentarios_Estado",SqlDbType.SmallInt,4,0} ,
          new Object[] {"@TrTareaComentarios_FechaCreacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrTareaComentarios_FechaModificacion",SqlDbType.DateTime,8,0} ,
          new Object[] {"@TrTareaComentarios_IDTarea",SqlDbType.Decimal,13,0} ,
          new Object[] {"@TrTareaComentarios_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT000512 ;
          prmT000512 = new Object[] {
          new Object[] {"@TrTareaComentarios_ID",SqlDbType.Decimal,13,0}
          } ;
          Object[] prmT000513 ;
          prmT000513 = new Object[] {
          } ;
          Object[] prmT000514 ;
          prmT000514 = new Object[] {
          new Object[] {"@TrTareaComentarios_IDTarea",SqlDbType.Decimal,13,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("T00052", "SELECT [TrTareaComentarios_ID], [TrTareaComentarios_Descripcion], [TrTareaComentarios_Estado], [TrTareaComentarios_FechaCreacion], [TrTareaComentarios_FechaModificacion], [TrTareaComentarios_IDTarea] AS TrTareaComentarios_IDTarea FROM TABLERO.[TrTareaComentarios] WITH (UPDLOCK) WHERE [TrTareaComentarios_ID] = @TrTareaComentarios_ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00052,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00053", "SELECT [TrTareaComentarios_ID], [TrTareaComentarios_Descripcion], [TrTareaComentarios_Estado], [TrTareaComentarios_FechaCreacion], [TrTareaComentarios_FechaModificacion], [TrTareaComentarios_IDTarea] AS TrTareaComentarios_IDTarea FROM TABLERO.[TrTareaComentarios] WHERE [TrTareaComentarios_ID] = @TrTareaComentarios_ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00053,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00054", "SELECT [TrGestionTareas_ID] AS TrTareaComentarios_IDTarea FROM TABLERO.[TrGestionTareas] WHERE [TrGestionTareas_ID] = @TrTareaComentarios_IDTarea ",true, GxErrorMask.GX_NOMASK, false, this,prmT00054,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00055", "SELECT TM1.[TrTareaComentarios_ID], TM1.[TrTareaComentarios_Descripcion], TM1.[TrTareaComentarios_Estado], TM1.[TrTareaComentarios_FechaCreacion], TM1.[TrTareaComentarios_FechaModificacion], TM1.[TrTareaComentarios_IDTarea] AS TrTareaComentarios_IDTarea FROM TABLERO.[TrTareaComentarios] TM1 WHERE TM1.[TrTareaComentarios_ID] = @TrTareaComentarios_ID ORDER BY TM1.[TrTareaComentarios_ID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00055,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00056", "SELECT [TrGestionTareas_ID] AS TrTareaComentarios_IDTarea FROM TABLERO.[TrGestionTareas] WHERE [TrGestionTareas_ID] = @TrTareaComentarios_IDTarea ",true, GxErrorMask.GX_NOMASK, false, this,prmT00056,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00057", "SELECT [TrTareaComentarios_ID] FROM TABLERO.[TrTareaComentarios] WHERE [TrTareaComentarios_ID] = @TrTareaComentarios_ID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00057,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00058", "SELECT TOP 1 [TrTareaComentarios_ID] FROM TABLERO.[TrTareaComentarios] WHERE ( [TrTareaComentarios_ID] > @TrTareaComentarios_ID) ORDER BY [TrTareaComentarios_ID]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00058,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00059", "SELECT TOP 1 [TrTareaComentarios_ID] FROM TABLERO.[TrTareaComentarios] WHERE ( [TrTareaComentarios_ID] < @TrTareaComentarios_ID) ORDER BY [TrTareaComentarios_ID] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00059,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000510", "INSERT INTO TABLERO.[TrTareaComentarios]([TrTareaComentarios_Descripcion], [TrTareaComentarios_Estado], [TrTareaComentarios_FechaCreacion], [TrTareaComentarios_FechaModificacion], [TrTareaComentarios_IDTarea]) VALUES(@TrTareaComentarios_Descripcion, @TrTareaComentarios_Estado, @TrTareaComentarios_FechaCreacion, @TrTareaComentarios_FechaModificacion, @TrTareaComentarios_IDTarea); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000510)
             ,new CursorDef("T000511", "UPDATE TABLERO.[TrTareaComentarios] SET [TrTareaComentarios_Descripcion]=@TrTareaComentarios_Descripcion, [TrTareaComentarios_Estado]=@TrTareaComentarios_Estado, [TrTareaComentarios_FechaCreacion]=@TrTareaComentarios_FechaCreacion, [TrTareaComentarios_FechaModificacion]=@TrTareaComentarios_FechaModificacion, [TrTareaComentarios_IDTarea]=@TrTareaComentarios_IDTarea  WHERE [TrTareaComentarios_ID] = @TrTareaComentarios_ID", GxErrorMask.GX_NOMASK,prmT000511)
             ,new CursorDef("T000512", "DELETE FROM TABLERO.[TrTareaComentarios]  WHERE [TrTareaComentarios_ID] = @TrTareaComentarios_ID", GxErrorMask.GX_NOMASK,prmT000512)
             ,new CursorDef("T000513", "SELECT [TrTareaComentarios_ID] FROM TABLERO.[TrTareaComentarios] ORDER BY [TrTareaComentarios_ID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000513,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000514", "SELECT [TrGestionTareas_ID] AS TrTareaComentarios_IDTarea FROM TABLERO.[TrGestionTareas] WHERE [TrGestionTareas_ID] = @TrTareaComentarios_IDTarea ",true, GxErrorMask.GX_NOMASK, false, this,prmT000514,1, GxCacheFrequency.OFF ,true,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                ((String[]) buf[1])[0] = rslt.getLongVarchar(2) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3) ;
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(4) ;
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(5) ;
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((long[]) buf[9])[0] = rslt.getLong(6) ;
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                ((String[]) buf[1])[0] = rslt.getLongVarchar(2) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3) ;
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(4) ;
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(5) ;
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((long[]) buf[9])[0] = rslt.getLong(6) ;
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                ((String[]) buf[1])[0] = rslt.getLongVarchar(2) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3) ;
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(4) ;
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(5) ;
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((long[]) buf[9])[0] = rslt.getLong(6) ;
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                return;
             case 5 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                return;
             case 6 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                return;
             case 7 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                return;
             case 8 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                return;
             case 11 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                return;
             case 12 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                return;
       }
    }

    public void setParameters( int cursor ,
                               IFieldSetter stmt ,
                               Object[] parms )
    {
       switch ( cursor )
       {
             case 0 :
                stmt.SetParameter(1, (long)parms[0]);
                return;
             case 1 :
                stmt.SetParameter(1, (long)parms[0]);
                return;
             case 2 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.Decimal );
                }
                else
                {
                   stmt.SetParameter(1, (long)parms[1]);
                }
                return;
             case 3 :
                stmt.SetParameter(1, (long)parms[0]);
                return;
             case 4 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.Decimal );
                }
                else
                {
                   stmt.SetParameter(1, (long)parms[1]);
                }
                return;
             case 5 :
                stmt.SetParameter(1, (long)parms[0]);
                return;
             case 6 :
                stmt.SetParameter(1, (long)parms[0]);
                return;
             case 7 :
                stmt.SetParameter(1, (long)parms[0]);
                return;
             case 8 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(1, (String)parms[1]);
                }
                if ( (bool)parms[2] )
                {
                   stmt.setNull( 2 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(2, (short)parms[3]);
                }
                if ( (bool)parms[4] )
                {
                   stmt.setNull( 3 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(3, (DateTime)parms[5]);
                }
                if ( (bool)parms[6] )
                {
                   stmt.setNull( 4 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(4, (DateTime)parms[7]);
                }
                if ( (bool)parms[8] )
                {
                   stmt.setNull( 5 , SqlDbType.Decimal );
                }
                else
                {
                   stmt.SetParameter(5, (long)parms[9]);
                }
                return;
             case 9 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.NVarChar );
                }
                else
                {
                   stmt.SetParameter(1, (String)parms[1]);
                }
                if ( (bool)parms[2] )
                {
                   stmt.setNull( 2 , SqlDbType.SmallInt );
                }
                else
                {
                   stmt.SetParameter(2, (short)parms[3]);
                }
                if ( (bool)parms[4] )
                {
                   stmt.setNull( 3 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(3, (DateTime)parms[5]);
                }
                if ( (bool)parms[6] )
                {
                   stmt.setNull( 4 , SqlDbType.DateTime );
                }
                else
                {
                   stmt.SetParameter(4, (DateTime)parms[7]);
                }
                if ( (bool)parms[8] )
                {
                   stmt.setNull( 5 , SqlDbType.Decimal );
                }
                else
                {
                   stmt.SetParameter(5, (long)parms[9]);
                }
                stmt.SetParameter(6, (long)parms[10]);
                return;
             case 10 :
                stmt.SetParameter(1, (long)parms[0]);
                return;
             case 12 :
                if ( (bool)parms[0] )
                {
                   stmt.setNull( 1 , SqlDbType.Decimal );
                }
                else
                {
                   stmt.SetParameter(1, (long)parms[1]);
                }
                return;
       }
    }

 }

}
