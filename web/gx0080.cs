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
   public class gx0080 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx0080( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public gx0080( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( out long aP0_pTrTareasEtiquetas_ID )
      {
         this.AV8pTrTareasEtiquetas_ID = 0 ;
         executePrivate();
         aP0_pTrTareasEtiquetas_ID=this.AV8pTrTareasEtiquetas_ID;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
            {
               nRC_GXsfl_44 = (int)(NumberUtil.Val( GetNextPar( ), "."));
               nGXsfl_44_idx = (int)(NumberUtil.Val( GetNextPar( ), "."));
               sGXsfl_44_idx = GetNextPar( );
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrGrid1_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid1") == 0 )
            {
               subGrid1_Rows = (int)(NumberUtil.Val( GetNextPar( ), "."));
               AV6cTrTareasEtiquetas_ID = (long)(NumberUtil.Val( GetNextPar( ), "."));
               AV10cTrTareasEtiquetas_TareaID = (long)(NumberUtil.Val( GetNextPar( ), "."));
               AV11cTrTareasEtiquetas_IDEtiqueta = (long)(NumberUtil.Val( GetNextPar( ), "."));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid1_refresh( subGrid1_Rows, AV6cTrTareasEtiquetas_ID, AV10cTrTareasEtiquetas_TareaID, AV11cTrTareasEtiquetas_IDEtiqueta) ;
               AddString( context.getJSONResponse( )) ;
               return  ;
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
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               AV8pTrTareasEtiquetas_ID = (long)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV8pTrTareasEtiquetas_ID", StringUtil.LTrimStr( (decimal)(AV8pTrTareasEtiquetas_ID), 13, 0));
            }
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("rwdpromptmasterpage", "GeneXus.Programs.rwdpromptmasterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,true);
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

      public override short ExecuteStartEvent( )
      {
         PA282( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START282( ) ;
         }
         return gxajaxcallmode ;
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
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 947160), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 947160), false, true);
         context.AddJavascriptSource("gxcfg.js", "?20221020219097", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle = bodyStyle + "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle = bodyStyle + " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0080.aspx") + "?" + UrlEncode("" +AV8pTrTareasEtiquetas_ID)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCTRTAREASETIQUETAS_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cTrTareasEtiquetas_ID), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCTRTAREASETIQUETAS_TAREAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cTrTareasEtiquetas_TareaID), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCTRTAREASETIQUETAS_IDETIQUETA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cTrTareasEtiquetas_IDEtiqueta), 13, 0, ".", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_44", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_44), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPTRTAREASETIQUETAS_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8pTrTareasEtiquetas_ID), 13, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "TRTAREASETIQUETAS_IDFILTERCONTAINER_Class", StringUtil.RTrim( divTrtareasetiquetas_idfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TRTAREASETIQUETAS_TAREAIDFILTERCONTAINER_Class", StringUtil.RTrim( divTrtareasetiquetas_tareaidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TRTAREASETIQUETAS_IDETIQUETAFILTERCONTAINER_Class", StringUtil.RTrim( divTrtareasetiquetas_idetiquetafiltercontainer_Class));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", "notset");
         SendAjaxEncryptionKey();
         SendSecurityToken((String)(sPrefix));
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

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE282( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT282( ) ;
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
         return formatLink("gx0080.aspx") + "?" + UrlEncode("" +AV8pTrTareasEtiquetas_ID) ;
      }

      public override String GetPgmname( )
      {
         return "Gx0080" ;
      }

      public override String GetPgmdesc( )
      {
         return "Selection List Tr Tareas Etiquetas" ;
      }

      protected void WB280( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMain_Internalname, 1, 0, "px", 0, "px", "ContainerFluid PromptContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 PromptAdvancedBarCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAdvancedcontainer_Internalname, 1, 0, "px", 0, "px", divAdvancedcontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTrtareasetiquetas_idfiltercontainer_Internalname, 1, 0, "px", 0, "px", divTrtareasetiquetas_idfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltrtareasetiquetas_idfilter_Internalname, "Tr Tareas Etiquetas_ID", "", "", lblLbltrtareasetiquetas_idfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11281_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 1, "HLP_Gx0080.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtrtareasetiquetas_id_Internalname, "Tr Tareas Etiquetas_ID", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_44_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtrtareasetiquetas_id_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cTrTareasEtiquetas_ID), 13, 0, ".", "")), ((edtavCtrtareasetiquetas_id_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV6cTrTareasEtiquetas_ID), "ZZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV6cTrTareasEtiquetas_ID), "ZZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtrtareasetiquetas_id_Jsonclick, 0, "Attribute", "", "", "", "", edtavCtrtareasetiquetas_id_Visible, edtavCtrtareasetiquetas_id_Enabled, 0, "number", "1", 13, "chr", 1, "row", 13, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0080.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTrtareasetiquetas_tareaidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divTrtareasetiquetas_tareaidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltrtareasetiquetas_tareaidfilter_Internalname, "Tareas_ID", "", "", lblLbltrtareasetiquetas_tareaidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12281_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 1, "HLP_Gx0080.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtrtareasetiquetas_tareaid_Internalname, "Tareas_ID", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_44_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtrtareasetiquetas_tareaid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cTrTareasEtiquetas_TareaID), 13, 0, ".", "")), ((edtavCtrtareasetiquetas_tareaid_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV10cTrTareasEtiquetas_TareaID), "ZZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV10cTrTareasEtiquetas_TareaID), "ZZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtrtareasetiquetas_tareaid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCtrtareasetiquetas_tareaid_Visible, edtavCtrtareasetiquetas_tareaid_Enabled, 0, "number", "1", 13, "chr", 1, "row", 13, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0080.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTrtareasetiquetas_idetiquetafiltercontainer_Internalname, 1, 0, "px", 0, "px", divTrtareasetiquetas_idetiquetafiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltrtareasetiquetas_idetiquetafilter_Internalname, "Tr Tareas Etiquetas_IDEtiqueta", "", "", lblLbltrtareasetiquetas_idetiquetafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13281_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 1, "HLP_Gx0080.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtrtareasetiquetas_idetiqueta_Internalname, "Tr Tareas Etiquetas_IDEtiqueta", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_44_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtrtareasetiquetas_idetiqueta_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cTrTareasEtiquetas_IDEtiqueta), 13, 0, ".", "")), ((edtavCtrtareasetiquetas_idetiqueta_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV11cTrTareasEtiquetas_IDEtiqueta), "ZZZZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV11cTrTareasEtiquetas_IDEtiqueta), "ZZZZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtrtareasetiquetas_idetiqueta_Jsonclick, 0, "Attribute", "", "", "", "", edtavCtrtareasetiquetas_idetiqueta_Visible, edtavCtrtareasetiquetas_idetiqueta_Enabled, 0, "number", "1", 13, "chr", 1, "row", 13, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0080.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 WWGridCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-sm hidden-md hidden-lg ToggleCell", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(44), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e14281_client"+"'", TempTags, "", 2, "HLP_Gx0080.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"44\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
               /* Subfile titles */
               context.WriteHtmlText( "<tr") ;
               context.WriteHtmlTextNl( ">") ;
               if ( subGrid1_Backcolorstyle == 0 )
               {
                  subGrid1_Titlebackstyle = 0;
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Title";
                  }
               }
               else
               {
                  subGrid1_Titlebackstyle = 1;
                  if ( subGrid1_Backcolorstyle == 1 )
                  {
                     subGrid1_Titlebackcolor = subGrid1_Allbackcolor;
                     if ( StringUtil.Len( subGrid1_Class) > 0 )
                     {
                        subGrid1_Linesclass = subGrid1_Class+"UniformTitle";
                     }
                  }
                  else
                  {
                     if ( StringUtil.Len( subGrid1_Class) > 0 )
                     {
                        subGrid1_Linesclass = subGrid1_Class+"Title";
                     }
                  }
               }
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"SelectionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Tareas Etiquetas_ID") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Tareas_ID") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Tareas Etiquetas_IDEtiqueta") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
               Grid1Container.AddObjectProperty("GridName", "Grid1");
            }
            else
            {
               if ( isAjaxCallMode( ) )
               {
                  Grid1Container = new GXWebGrid( context);
               }
               else
               {
                  Grid1Container.Clear();
               }
               Grid1Container.SetWrapped(nGXWrapped);
               Grid1Container.AddObjectProperty("GridName", "Grid1");
               Grid1Container.AddObjectProperty("Header", subGrid1_Header);
               Grid1Container.AddObjectProperty("Class", "PromptGrid");
               Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("CmpContext", "");
               Grid1Container.AddObjectProperty("InMasterPage", "false");
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.convertURL( AV5LinkSelection));
               Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtavLinkselection_Link));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A51TrTareasEtiquetas_ID), 13, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A52TrTareasEtiquetas_TareaID), 13, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A53TrTareasEtiquetas_IDEtiqueta), 13, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectedindex), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowselection), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectioncolor), 9, 0, ".", "")));
               Grid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowhovering), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Hoveringcolor), 9, 0, ".", "")));
               Grid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowcollapsing), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 44 )
         {
            wbEnd = 0;
            nRC_GXsfl_44 = (int)(nGXsfl_44_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
               Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(44), 2, 0)+","+"null"+");", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0080.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 44 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
                  Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START282( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus C# 16_0_10-142546", 0) ;
            }
            Form.Meta.addItem("description", "Selection List Tr Tareas Etiquetas", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP280( ) ;
      }

      protected void WS282( )
      {
         START282( ) ;
         EVT282( ) ;
      }

      protected void EVT282( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
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
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRID1PAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRID1PAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid1_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid1_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid1_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid1_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 4), "LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) )
                           {
                              nGXsfl_44_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_44_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_44_idx), 4, 0), 4, "0");
                              SubsflControlProps_442( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV14Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_44_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A51TrTareasEtiquetas_ID = (long)(context.localUtil.CToN( cgiGet( edtTrTareasEtiquetas_ID_Internalname), ".", ","));
                              A52TrTareasEtiquetas_TareaID = (long)(context.localUtil.CToN( cgiGet( edtTrTareasEtiquetas_TareaID_Internalname), ".", ","));
                              A53TrTareasEtiquetas_IDEtiqueta = (long)(context.localUtil.CToN( cgiGet( edtTrTareasEtiquetas_IDEtiqueta_Internalname), ".", ","));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E15282 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E16282 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Ctrtareasetiquetas_id Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTRTAREASETIQUETAS_ID"), ".", ",") != Convert.ToDecimal( AV6cTrTareasEtiquetas_ID )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctrtareasetiquetas_tareaid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTRTAREASETIQUETAS_TAREAID"), ".", ",") != Convert.ToDecimal( AV10cTrTareasEtiquetas_TareaID )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctrtareasetiquetas_idetiqueta Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTRTAREASETIQUETAS_IDETIQUETA"), ".", ",") != Convert.ToDecimal( AV11cTrTareasEtiquetas_IDEtiqueta )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E17282 ();
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE282( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA282( )
      {
         if ( nDonePA == 0 )
         {
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
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_442( ) ;
         while ( nGXsfl_44_idx <= nRC_GXsfl_44 )
         {
            sendrow_442( ) ;
            nGXsfl_44_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_44_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_44_idx+1);
            sGXsfl_44_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_44_idx), 4, 0), 4, "0");
            SubsflControlProps_442( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        long AV6cTrTareasEtiquetas_ID ,
                                        long AV10cTrTareasEtiquetas_TareaID ,
                                        long AV11cTrTareasEtiquetas_IDEtiqueta )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF282( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_TRTAREASETIQUETAS_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A51TrTareasEtiquetas_ID), "ZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "TRTAREASETIQUETAS_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A51TrTareasEtiquetas_ID), 13, 0, ".", "")));
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF282( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      protected void RF282( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 44;
         nGXsfl_44_idx = 1;
         sGXsfl_44_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_44_idx), 4, 0), 4, "0");
         SubsflControlProps_442( ) ;
         bGXsfl_44_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "PromptGrid");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_442( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV10cTrTareasEtiquetas_TareaID ,
                                                 AV11cTrTareasEtiquetas_IDEtiqueta ,
                                                 A52TrTareasEtiquetas_TareaID ,
                                                 A53TrTareasEtiquetas_IDEtiqueta ,
                                                 AV6cTrTareasEtiquetas_ID } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                                 }
            } ) ;
            /* Using cursor H00282 */
            pr_default.execute(0, new Object[] {AV6cTrTareasEtiquetas_ID, AV10cTrTareasEtiquetas_TareaID, AV11cTrTareasEtiquetas_IDEtiqueta, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_44_idx = 1;
            sGXsfl_44_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_44_idx), 4, 0), 4, "0");
            SubsflControlProps_442( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A53TrTareasEtiquetas_IDEtiqueta = H00282_A53TrTareasEtiquetas_IDEtiqueta[0];
               A52TrTareasEtiquetas_TareaID = H00282_A52TrTareasEtiquetas_TareaID[0];
               A51TrTareasEtiquetas_ID = H00282_A51TrTareasEtiquetas_ID[0];
               /* Execute user event: Load */
               E16282 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 44;
            WB280( ) ;
         }
         bGXsfl_44_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes282( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_TRTAREASETIQUETAS_ID"+"_"+sGXsfl_44_idx, GetSecureSignedToken( sGXsfl_44_idx, context.localUtil.Format( (decimal)(A51TrTareasEtiquetas_ID), "ZZZZZZZZZZZZ9"), context));
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( ))))) ;
         }
         return (int)(NumberUtil.Int( (long)(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( ))))+1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV10cTrTareasEtiquetas_TareaID ,
                                              AV11cTrTareasEtiquetas_IDEtiqueta ,
                                              A52TrTareasEtiquetas_TareaID ,
                                              A53TrTareasEtiquetas_IDEtiqueta ,
                                              AV6cTrTareasEtiquetas_ID } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         } ) ;
         /* Using cursor H00283 */
         pr_default.execute(1, new Object[] {AV6cTrTareasEtiquetas_ID, AV10cTrTareasEtiquetas_TareaID, AV11cTrTareasEtiquetas_IDEtiqueta});
         GRID1_nRecordCount = H00283_AGRID1_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID1_nRecordCount) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         return (int)(10*1) ;
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(GRID1_nFirstRecordOnPage/ (decimal)(subGrid1_fnc_Recordsperpage( ))))+1) ;
      }

      protected short subgrid1_firstpage( )
      {
         GRID1_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTrTareasEtiquetas_ID, AV10cTrTareasEtiquetas_TareaID, AV11cTrTareasEtiquetas_IDEtiqueta) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_nextpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ( GRID1_nRecordCount >= subGrid1_fnc_Recordsperpage( ) ) && ( GRID1_nEOF == 0 ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage+subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTrTareasEtiquetas_ID, AV10cTrTareasEtiquetas_TareaID, AV11cTrTareasEtiquetas_IDEtiqueta) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID1_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid1_previouspage( )
      {
         if ( GRID1_nFirstRecordOnPage >= subGrid1_fnc_Recordsperpage( ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage-subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTrTareasEtiquetas_ID, AV10cTrTareasEtiquetas_TareaID, AV11cTrTareasEtiquetas_IDEtiqueta) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_lastpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( GRID1_nRecordCount > subGrid1_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-subGrid1_fnc_Recordsperpage( ));
            }
            else
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTrTareasEtiquetas_ID, AV10cTrTareasEtiquetas_TareaID, AV11cTrTareasEtiquetas_IDEtiqueta) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid1_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID1_nFirstRecordOnPage = (long)(subGrid1_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTrTareasEtiquetas_ID, AV10cTrTareasEtiquetas_TareaID, AV11cTrTareasEtiquetas_IDEtiqueta) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
      }

      protected void STRUP280( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E15282 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_44 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_44"), ".", ","));
            GRID1_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ".", ","));
            GRID1_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ".", ","));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCtrtareasetiquetas_id_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCtrtareasetiquetas_id_Internalname), ".", ",") > Convert.ToDecimal( 9999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCTRTAREASETIQUETAS_ID");
               GX_FocusControl = edtavCtrtareasetiquetas_id_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cTrTareasEtiquetas_ID = 0;
               AssignAttri("", false, "AV6cTrTareasEtiquetas_ID", StringUtil.LTrimStr( (decimal)(AV6cTrTareasEtiquetas_ID), 13, 0));
            }
            else
            {
               AV6cTrTareasEtiquetas_ID = (long)(context.localUtil.CToN( cgiGet( edtavCtrtareasetiquetas_id_Internalname), ".", ","));
               AssignAttri("", false, "AV6cTrTareasEtiquetas_ID", StringUtil.LTrimStr( (decimal)(AV6cTrTareasEtiquetas_ID), 13, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCtrtareasetiquetas_tareaid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCtrtareasetiquetas_tareaid_Internalname), ".", ",") > Convert.ToDecimal( 9999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCTRTAREASETIQUETAS_TAREAID");
               GX_FocusControl = edtavCtrtareasetiquetas_tareaid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cTrTareasEtiquetas_TareaID = 0;
               AssignAttri("", false, "AV10cTrTareasEtiquetas_TareaID", StringUtil.LTrimStr( (decimal)(AV10cTrTareasEtiquetas_TareaID), 13, 0));
            }
            else
            {
               AV10cTrTareasEtiquetas_TareaID = (long)(context.localUtil.CToN( cgiGet( edtavCtrtareasetiquetas_tareaid_Internalname), ".", ","));
               AssignAttri("", false, "AV10cTrTareasEtiquetas_TareaID", StringUtil.LTrimStr( (decimal)(AV10cTrTareasEtiquetas_TareaID), 13, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCtrtareasetiquetas_idetiqueta_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCtrtareasetiquetas_idetiqueta_Internalname), ".", ",") > Convert.ToDecimal( 9999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCTRTAREASETIQUETAS_IDETIQUETA");
               GX_FocusControl = edtavCtrtareasetiquetas_idetiqueta_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11cTrTareasEtiquetas_IDEtiqueta = 0;
               AssignAttri("", false, "AV11cTrTareasEtiquetas_IDEtiqueta", StringUtil.LTrimStr( (decimal)(AV11cTrTareasEtiquetas_IDEtiqueta), 13, 0));
            }
            else
            {
               AV11cTrTareasEtiquetas_IDEtiqueta = (long)(context.localUtil.CToN( cgiGet( edtavCtrtareasetiquetas_idetiqueta_Internalname), ".", ","));
               AssignAttri("", false, "AV11cTrTareasEtiquetas_IDEtiqueta", StringUtil.LTrimStr( (decimal)(AV11cTrTareasEtiquetas_IDEtiqueta), 13, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTRTAREASETIQUETAS_ID"), ".", ",") != Convert.ToDecimal( AV6cTrTareasEtiquetas_ID )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTRTAREASETIQUETAS_TAREAID"), ".", ",") != Convert.ToDecimal( AV10cTrTareasEtiquetas_TareaID )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTRTAREASETIQUETAS_IDETIQUETA"), ".", ",") != Convert.ToDecimal( AV11cTrTareasEtiquetas_IDEtiqueta )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E15282 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E15282( )
      {
         /* Start Routine */
         Form.Caption = StringUtil.Format( "Selection List %1", "Tr Tareas Etiquetas", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV9ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E16282( )
      {
         /* Load Routine */
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV14Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )));
         sendrow_442( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_44_Refreshing )
         {
            context.DoAjaxLoad(44, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E17282 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E17282( )
      {
         /* Enter Routine */
         AV8pTrTareasEtiquetas_ID = A51TrTareasEtiquetas_ID;
         AssignAttri("", false, "AV8pTrTareasEtiquetas_ID", StringUtil.LTrimStr( (decimal)(AV8pTrTareasEtiquetas_ID), 13, 0));
         context.setWebReturnParms(new Object[] {(long)AV8pTrTareasEtiquetas_ID});
         context.setWebReturnParmsMetadata(new Object[] {"AV8pTrTareasEtiquetas_ID"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV8pTrTareasEtiquetas_ID = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV8pTrTareasEtiquetas_ID", StringUtil.LTrimStr( (decimal)(AV8pTrTareasEtiquetas_ID), 13, 0));
      }

      public override String getresponse( String sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA282( ) ;
         WS282( ) ;
         WE282( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( String sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( ) ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((String)Form.Jscriptsrc.Item(idxLst))), "?20221020219129", true, true);
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
         context.AddJavascriptSource("gx0080.js", "?20221020219130", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_442( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_44_idx;
         edtTrTareasEtiquetas_ID_Internalname = "TRTAREASETIQUETAS_ID_"+sGXsfl_44_idx;
         edtTrTareasEtiquetas_TareaID_Internalname = "TRTAREASETIQUETAS_TAREAID_"+sGXsfl_44_idx;
         edtTrTareasEtiquetas_IDEtiqueta_Internalname = "TRTAREASETIQUETAS_IDETIQUETA_"+sGXsfl_44_idx;
      }

      protected void SubsflControlProps_fel_442( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_44_fel_idx;
         edtTrTareasEtiquetas_ID_Internalname = "TRTAREASETIQUETAS_ID_"+sGXsfl_44_fel_idx;
         edtTrTareasEtiquetas_TareaID_Internalname = "TRTAREASETIQUETAS_TAREAID_"+sGXsfl_44_fel_idx;
         edtTrTareasEtiquetas_IDEtiqueta_Internalname = "TRTAREASETIQUETAS_IDETIQUETA_"+sGXsfl_44_fel_idx;
      }

      protected void sendrow_442( )
      {
         SubsflControlProps_442( ) ;
         WB280( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_44_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
         {
            Grid1Row = GXWebRow.GetNew(context,Grid1Container);
            if ( subGrid1_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid1_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
            }
            else if ( subGrid1_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid1_Backstyle = 0;
               subGrid1_Backcolor = subGrid1_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Uniform";
               }
            }
            else if ( subGrid1_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
               subGrid1_Backcolor = (int)(0x0);
            }
            else if ( subGrid1_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( ((int)((nGXsfl_44_idx) % (2))) == 0 )
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Even";
                  }
               }
               else
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Odd";
                  }
               }
            }
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"PromptGrid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_44_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A51TrTareasEtiquetas_ID), 13, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_44_Refreshing);
            ClassString = "SelectionAttribute";
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV14Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV14Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(String)edtavLinkselection_Internalname,(String)sImgUrl,(String)edtavLinkselection_Link,(String)"",(String)"",context.GetTheme( ),(short)-1,(short)1,(String)"",(String)"",(short)0,(short)-1,(short)0,(String)"px",(short)0,(String)"px",(short)0,(short)0,(short)0,(String)"",(String)"",(String)StyleString,(String)ClassString,(String)"WWActionColumn",(String)"",(String)"",(String)"",(String)"",(String)"",(String)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrTareasEtiquetas_ID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A51TrTareasEtiquetas_ID), 13, 0, ".", "")),context.localUtil.Format( (decimal)(A51TrTareasEtiquetas_ID), "ZZZZZZZZZZZZ9"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrTareasEtiquetas_ID_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn",(String)"",(short)-1,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)13,(short)0,(short)0,(short)44,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrTareasEtiquetas_TareaID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A52TrTareasEtiquetas_TareaID), 13, 0, ".", "")),context.localUtil.Format( (decimal)(A52TrTareasEtiquetas_TareaID), "ZZZZZZZZZZZZ9"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrTareasEtiquetas_TareaID_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn OptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)13,(short)0,(short)0,(short)44,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(String)edtTrTareasEtiquetas_IDEtiqueta_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A53TrTareasEtiquetas_IDEtiqueta), 13, 0, ".", "")),context.localUtil.Format( (decimal)(A53TrTareasEtiquetas_IDEtiqueta), "ZZZZZZZZZZZZ9"),(String)"",(String)"'"+""+"'"+",false,"+"'"+""+"'",(String)"",(String)"",(String)"",(String)"",(String)edtTrTareasEtiquetas_IDEtiqueta_Jsonclick,(short)0,(String)"Attribute",(String)"",(String)ROClassString,(String)"WWColumn OptionalColumn",(String)"",(short)-1,(short)0,(short)0,(String)"number",(String)"1",(short)0,(String)"px",(short)17,(String)"px",(short)13,(short)0,(short)0,(short)44,(short)1,(short)-1,(short)0,(bool)true,(String)"",(String)"right",(bool)false,(String)""});
            send_integrity_lvl_hashes282( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_44_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_44_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_44_idx+1);
            sGXsfl_44_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_44_idx), 4, 0), 4, "0");
            SubsflControlProps_442( ) ;
         }
         /* End function sendrow_442 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblLbltrtareasetiquetas_idfilter_Internalname = "LBLTRTAREASETIQUETAS_IDFILTER";
         edtavCtrtareasetiquetas_id_Internalname = "vCTRTAREASETIQUETAS_ID";
         divTrtareasetiquetas_idfiltercontainer_Internalname = "TRTAREASETIQUETAS_IDFILTERCONTAINER";
         lblLbltrtareasetiquetas_tareaidfilter_Internalname = "LBLTRTAREASETIQUETAS_TAREAIDFILTER";
         edtavCtrtareasetiquetas_tareaid_Internalname = "vCTRTAREASETIQUETAS_TAREAID";
         divTrtareasetiquetas_tareaidfiltercontainer_Internalname = "TRTAREASETIQUETAS_TAREAIDFILTERCONTAINER";
         lblLbltrtareasetiquetas_idetiquetafilter_Internalname = "LBLTRTAREASETIQUETAS_IDETIQUETAFILTER";
         edtavCtrtareasetiquetas_idetiqueta_Internalname = "vCTRTAREASETIQUETAS_IDETIQUETA";
         divTrtareasetiquetas_idetiquetafiltercontainer_Internalname = "TRTAREASETIQUETAS_IDETIQUETAFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtTrTareasEtiquetas_ID_Internalname = "TRTAREASETIQUETAS_ID";
         edtTrTareasEtiquetas_TareaID_Internalname = "TRTAREASETIQUETAS_TAREAID";
         edtTrTareasEtiquetas_IDEtiqueta_Internalname = "TRTAREASETIQUETAS_IDETIQUETA";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         divGridtable_Internalname = "GRIDTABLE";
         divMain_Internalname = "MAIN";
         Form.Internalname = "FORM";
         subGrid1_Internalname = "GRID1";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("K2BOrion");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtTrTareasEtiquetas_IDEtiqueta_Jsonclick = "";
         edtTrTareasEtiquetas_TareaID_Jsonclick = "";
         edtTrTareasEtiquetas_ID_Jsonclick = "";
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         edtavLinkselection_Link = "";
         subGrid1_Header = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCtrtareasetiquetas_idetiqueta_Jsonclick = "";
         edtavCtrtareasetiquetas_idetiqueta_Enabled = 1;
         edtavCtrtareasetiquetas_idetiqueta_Visible = 1;
         edtavCtrtareasetiquetas_tareaid_Jsonclick = "";
         edtavCtrtareasetiquetas_tareaid_Enabled = 1;
         edtavCtrtareasetiquetas_tareaid_Visible = 1;
         edtavCtrtareasetiquetas_id_Jsonclick = "";
         edtavCtrtareasetiquetas_id_Enabled = 1;
         edtavCtrtareasetiquetas_id_Visible = 1;
         divTrtareasetiquetas_idetiquetafiltercontainer_Class = "AdvancedContainerItem";
         divTrtareasetiquetas_tareaidfiltercontainer_Class = "AdvancedContainerItem";
         divTrtareasetiquetas_idfiltercontainer_Class = "AdvancedContainerItem";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List Tr Tareas Etiquetas";
         subGrid1_Rows = 10;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTrTareasEtiquetas_ID',fld:'vCTRTAREASETIQUETAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'AV10cTrTareasEtiquetas_TareaID',fld:'vCTRTAREASETIQUETAS_TAREAID',pic:'ZZZZZZZZZZZZ9'},{av:'AV11cTrTareasEtiquetas_IDEtiqueta',fld:'vCTRTAREASETIQUETAS_IDETIQUETA',pic:'ZZZZZZZZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E14281',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLTRTAREASETIQUETAS_IDFILTER.CLICK","{handler:'E11281',iparms:[{av:'divTrtareasetiquetas_idfiltercontainer_Class',ctrl:'TRTAREASETIQUETAS_IDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTRTAREASETIQUETAS_IDFILTER.CLICK",",oparms:[{av:'divTrtareasetiquetas_idfiltercontainer_Class',ctrl:'TRTAREASETIQUETAS_IDFILTERCONTAINER',prop:'Class'},{av:'edtavCtrtareasetiquetas_id_Visible',ctrl:'vCTRTAREASETIQUETAS_ID',prop:'Visible'}]}");
         setEventMetadata("LBLTRTAREASETIQUETAS_TAREAIDFILTER.CLICK","{handler:'E12281',iparms:[{av:'divTrtareasetiquetas_tareaidfiltercontainer_Class',ctrl:'TRTAREASETIQUETAS_TAREAIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTRTAREASETIQUETAS_TAREAIDFILTER.CLICK",",oparms:[{av:'divTrtareasetiquetas_tareaidfiltercontainer_Class',ctrl:'TRTAREASETIQUETAS_TAREAIDFILTERCONTAINER',prop:'Class'},{av:'edtavCtrtareasetiquetas_tareaid_Visible',ctrl:'vCTRTAREASETIQUETAS_TAREAID',prop:'Visible'}]}");
         setEventMetadata("LBLTRTAREASETIQUETAS_IDETIQUETAFILTER.CLICK","{handler:'E13281',iparms:[{av:'divTrtareasetiquetas_idetiquetafiltercontainer_Class',ctrl:'TRTAREASETIQUETAS_IDETIQUETAFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTRTAREASETIQUETAS_IDETIQUETAFILTER.CLICK",",oparms:[{av:'divTrtareasetiquetas_idetiquetafiltercontainer_Class',ctrl:'TRTAREASETIQUETAS_IDETIQUETAFILTERCONTAINER',prop:'Class'},{av:'edtavCtrtareasetiquetas_idetiqueta_Visible',ctrl:'vCTRTAREASETIQUETAS_IDETIQUETA',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E17282',iparms:[{av:'A51TrTareasEtiquetas_ID',fld:'TRTAREASETIQUETAS_ID',pic:'ZZZZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV8pTrTareasEtiquetas_ID',fld:'vPTRTAREASETIQUETAS_ID',pic:'ZZZZZZZZZZZZ9'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTrTareasEtiquetas_ID',fld:'vCTRTAREASETIQUETAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'AV10cTrTareasEtiquetas_TareaID',fld:'vCTRTAREASETIQUETAS_TAREAID',pic:'ZZZZZZZZZZZZ9'},{av:'AV11cTrTareasEtiquetas_IDEtiqueta',fld:'vCTRTAREASETIQUETAS_IDETIQUETA',pic:'ZZZZZZZZZZZZ9'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTrTareasEtiquetas_ID',fld:'vCTRTAREASETIQUETAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'AV10cTrTareasEtiquetas_TareaID',fld:'vCTRTAREASETIQUETAS_TAREAID',pic:'ZZZZZZZZZZZZ9'},{av:'AV11cTrTareasEtiquetas_IDEtiqueta',fld:'vCTRTAREASETIQUETAS_IDETIQUETA',pic:'ZZZZZZZZZZZZ9'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTrTareasEtiquetas_ID',fld:'vCTRTAREASETIQUETAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'AV10cTrTareasEtiquetas_TareaID',fld:'vCTRTAREASETIQUETAS_TAREAID',pic:'ZZZZZZZZZZZZ9'},{av:'AV11cTrTareasEtiquetas_IDEtiqueta',fld:'vCTRTAREASETIQUETAS_IDETIQUETA',pic:'ZZZZZZZZZZZZ9'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTrTareasEtiquetas_ID',fld:'vCTRTAREASETIQUETAS_ID',pic:'ZZZZZZZZZZZZ9'},{av:'AV10cTrTareasEtiquetas_TareaID',fld:'vCTRTAREASETIQUETAS_TAREAID',pic:'ZZZZZZZZZZZZ9'},{av:'AV11cTrTareasEtiquetas_IDEtiqueta',fld:'vCTRTAREASETIQUETAS_IDETIQUETA',pic:'ZZZZZZZZZZZZ9'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Trtareasetiquetas_idetiqueta',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
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
      }

      public override void initialize( )
      {
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLbltrtareasetiquetas_idfilter_Jsonclick = "";
         TempTags = "";
         lblLbltrtareasetiquetas_tareaidfilter_Jsonclick = "";
         lblLbltrtareasetiquetas_idetiquetafilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         subGrid1_Linesclass = "";
         Grid1Column = new GXWebColumn();
         AV5LinkSelection = "";
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV14Linkselection_GXI = "";
         scmdbuf = "";
         H00282_A53TrTareasEtiquetas_IDEtiqueta = new long[1] ;
         H00282_A52TrTareasEtiquetas_TareaID = new long[1] ;
         H00282_A51TrTareasEtiquetas_ID = new long[1] ;
         H00283_AGRID1_nRecordCount = new long[1] ;
         AV9ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sImgUrl = "";
         ROClassString = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0080__default(),
            new Object[][] {
                new Object[] {
               H00282_A53TrTareasEtiquetas_IDEtiqueta, H00282_A52TrTareasEtiquetas_TareaID, H00282_A51TrTareasEtiquetas_ID
               }
               , new Object[] {
               H00283_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid1_Backcolorstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private int nRC_GXsfl_44 ;
      private int nGXsfl_44_idx=1 ;
      private int subGrid1_Rows ;
      private int edtavCtrtareasetiquetas_id_Enabled ;
      private int edtavCtrtareasetiquetas_id_Visible ;
      private int edtavCtrtareasetiquetas_tareaid_Enabled ;
      private int edtavCtrtareasetiquetas_tareaid_Visible ;
      private int edtavCtrtareasetiquetas_idetiqueta_Enabled ;
      private int edtavCtrtareasetiquetas_idetiqueta_Visible ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV6cTrTareasEtiquetas_ID ;
      private long AV10cTrTareasEtiquetas_TareaID ;
      private long AV11cTrTareasEtiquetas_IDEtiqueta ;
      private long AV8pTrTareasEtiquetas_ID ;
      private long A51TrTareasEtiquetas_ID ;
      private long A52TrTareasEtiquetas_TareaID ;
      private long A53TrTareasEtiquetas_IDEtiqueta ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private String divAdvancedcontainer_Class ;
      private String bttBtntoggle_Class ;
      private String divTrtareasetiquetas_idfiltercontainer_Class ;
      private String divTrtareasetiquetas_tareaidfiltercontainer_Class ;
      private String divTrtareasetiquetas_idetiquetafiltercontainer_Class ;
      private String gxfirstwebparm ;
      private String gxfirstwebparm_bkp ;
      private String sGXsfl_44_idx="0001" ;
      private String sDynURL ;
      private String FormProcess ;
      private String bodyStyle ;
      private String GXKey ;
      private String GX_FocusControl ;
      private String sPrefix ;
      private String divMain_Internalname ;
      private String divAdvancedcontainer_Internalname ;
      private String divTrtareasetiquetas_idfiltercontainer_Internalname ;
      private String lblLbltrtareasetiquetas_idfilter_Internalname ;
      private String lblLbltrtareasetiquetas_idfilter_Jsonclick ;
      private String edtavCtrtareasetiquetas_id_Internalname ;
      private String TempTags ;
      private String edtavCtrtareasetiquetas_id_Jsonclick ;
      private String divTrtareasetiquetas_tareaidfiltercontainer_Internalname ;
      private String lblLbltrtareasetiquetas_tareaidfilter_Internalname ;
      private String lblLbltrtareasetiquetas_tareaidfilter_Jsonclick ;
      private String edtavCtrtareasetiquetas_tareaid_Internalname ;
      private String edtavCtrtareasetiquetas_tareaid_Jsonclick ;
      private String divTrtareasetiquetas_idetiquetafiltercontainer_Internalname ;
      private String lblLbltrtareasetiquetas_idetiquetafilter_Internalname ;
      private String lblLbltrtareasetiquetas_idetiquetafilter_Jsonclick ;
      private String edtavCtrtareasetiquetas_idetiqueta_Internalname ;
      private String edtavCtrtareasetiquetas_idetiqueta_Jsonclick ;
      private String divGridtable_Internalname ;
      private String ClassString ;
      private String StyleString ;
      private String bttBtntoggle_Internalname ;
      private String bttBtntoggle_Jsonclick ;
      private String sStyleString ;
      private String subGrid1_Internalname ;
      private String subGrid1_Class ;
      private String subGrid1_Linesclass ;
      private String subGrid1_Header ;
      private String edtavLinkselection_Link ;
      private String bttBtn_cancel_Internalname ;
      private String bttBtn_cancel_Jsonclick ;
      private String sEvt ;
      private String EvtGridId ;
      private String EvtRowId ;
      private String sEvtType ;
      private String edtavLinkselection_Internalname ;
      private String edtTrTareasEtiquetas_ID_Internalname ;
      private String edtTrTareasEtiquetas_TareaID_Internalname ;
      private String edtTrTareasEtiquetas_IDEtiqueta_Internalname ;
      private String scmdbuf ;
      private String AV9ADVANCED_LABEL_TEMPLATE ;
      private String sGXsfl_44_fel_idx="0001" ;
      private String sImgUrl ;
      private String ROClassString ;
      private String edtTrTareasEtiquetas_ID_Jsonclick ;
      private String edtTrTareasEtiquetas_TareaID_Jsonclick ;
      private String edtTrTareasEtiquetas_IDEtiqueta_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_44_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private String AV14Linkselection_GXI ;
      private String AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] H00282_A53TrTareasEtiquetas_IDEtiqueta ;
      private long[] H00282_A52TrTareasEtiquetas_TareaID ;
      private long[] H00282_A51TrTareasEtiquetas_ID ;
      private long[] H00283_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long aP0_pTrTareasEtiquetas_ID ;
      private GXWebForm Form ;
   }

   public class gx0080__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00282( IGxContext context ,
                                             long AV10cTrTareasEtiquetas_TareaID ,
                                             long AV11cTrTareasEtiquetas_IDEtiqueta ,
                                             long A52TrTareasEtiquetas_TareaID ,
                                             long A53TrTareasEtiquetas_IDEtiqueta ,
                                             long AV6cTrTareasEtiquetas_ID )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         short[] GXv_int1 ;
         GXv_int1 = new short [6] ;
         Object[] GXv_Object2 ;
         GXv_Object2 = new Object [2] ;
         String sSelectString ;
         String sFromString ;
         String sOrderString ;
         sSelectString = " [TrTareasEtiquetas_IDEtiqueta], [TrTareasEtiquetas_TareaID], [TrTareasEtiquetas_ID]";
         sFromString = " FROM TABLERO.[TrTareasEtiquetas]";
         sOrderString = "";
         sWhereString = sWhereString + " WHERE ([TrTareasEtiquetas_ID] >= @AV6cTrTareasEtiquetas_ID)";
         if ( ! (0==AV10cTrTareasEtiquetas_TareaID) )
         {
            sWhereString = sWhereString + " and ([TrTareasEtiquetas_TareaID] >= @AV10cTrTareasEtiquetas_TareaID)";
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV11cTrTareasEtiquetas_IDEtiqueta) )
         {
            sWhereString = sWhereString + " and ([TrTareasEtiquetas_IDEtiqueta] >= @AV11cTrTareasEtiquetas_IDEtiqueta)";
         }
         else
         {
            GXv_int1[2] = 1;
         }
         sOrderString = sOrderString + " ORDER BY [TrTareasEtiquetas_ID]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00283( IGxContext context ,
                                             long AV10cTrTareasEtiquetas_TareaID ,
                                             long AV11cTrTareasEtiquetas_IDEtiqueta ,
                                             long A52TrTareasEtiquetas_TareaID ,
                                             long A53TrTareasEtiquetas_IDEtiqueta ,
                                             long AV6cTrTareasEtiquetas_ID )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         short[] GXv_int3 ;
         GXv_int3 = new short [3] ;
         Object[] GXv_Object4 ;
         GXv_Object4 = new Object [2] ;
         scmdbuf = "SELECT COUNT(*) FROM TABLERO.[TrTareasEtiquetas]";
         scmdbuf = scmdbuf + " WHERE ([TrTareasEtiquetas_ID] >= @AV6cTrTareasEtiquetas_ID)";
         if ( ! (0==AV10cTrTareasEtiquetas_TareaID) )
         {
            sWhereString = sWhereString + " and ([TrTareasEtiquetas_TareaID] >= @AV10cTrTareasEtiquetas_TareaID)";
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (0==AV11cTrTareasEtiquetas_IDEtiqueta) )
         {
            sWhereString = sWhereString + " and ([TrTareasEtiquetas_IDEtiqueta] >= @AV11cTrTareasEtiquetas_IDEtiqueta)";
         }
         else
         {
            GXv_int3[2] = 1;
         }
         scmdbuf = scmdbuf + sWhereString;
         scmdbuf = scmdbuf + "";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00282(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (long)dynConstraints[4] );
               case 1 :
                     return conditional_H00283(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (long)dynConstraints[4] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00282 ;
          prmH00282 = new Object[] {
          new Object[] {"@AV6cTrTareasEtiquetas_ID",SqlDbType.Decimal,13,0} ,
          new Object[] {"@AV10cTrTareasEtiquetas_TareaID",SqlDbType.Decimal,13,0} ,
          new Object[] {"@AV11cTrTareasEtiquetas_IDEtiqueta",SqlDbType.Decimal,13,0} ,
          new Object[] {"@GXPagingFrom2",SqlDbType.Int,9,0} ,
          new Object[] {"@GXPagingTo2",SqlDbType.Int,9,0} ,
          new Object[] {"@GXPagingTo2",SqlDbType.Int,9,0}
          } ;
          Object[] prmH00283 ;
          prmH00283 = new Object[] {
          new Object[] {"@AV6cTrTareasEtiquetas_ID",SqlDbType.Decimal,13,0} ,
          new Object[] {"@AV10cTrTareasEtiquetas_TareaID",SqlDbType.Decimal,13,0} ,
          new Object[] {"@AV11cTrTareasEtiquetas_IDEtiqueta",SqlDbType.Decimal,13,0}
          } ;
          def= new CursorDef[] {
              new CursorDef("H00282", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00282,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00283", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00283,1, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2) ;
                ((long[]) buf[2])[0] = rslt.getLong(3) ;
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1) ;
                return;
       }
    }

    public void setParameters( int cursor ,
                               IFieldSetter stmt ,
                               Object[] parms )
    {
       short sIdx ;
       switch ( cursor )
       {
             case 0 :
                sIdx = 0;
                if ( (short)parms[0] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (long)parms[6]);
                }
                if ( (short)parms[1] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (long)parms[7]);
                }
                if ( (short)parms[2] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (long)parms[8]);
                }
                if ( (short)parms[3] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[9]);
                }
                if ( (short)parms[4] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[10]);
                }
                if ( (short)parms[5] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (int)parms[11]);
                }
                return;
             case 1 :
                sIdx = 0;
                if ( (short)parms[0] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (long)parms[3]);
                }
                if ( (short)parms[1] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (long)parms[4]);
                }
                if ( (short)parms[2] == 0 )
                {
                   sIdx = (short)(sIdx+1);
                   stmt.SetParameter(sIdx, (long)parms[5]);
                }
                return;
       }
    }

 }

}
