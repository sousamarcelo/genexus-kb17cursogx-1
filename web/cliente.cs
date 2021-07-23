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
   public class cliente : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         toggleJsOutput = isJsOutputEnabled( );
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridcliente_endereco") == 0 )
         {
            nRC_GXsfl_53 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_53"), "."));
            nGXsfl_53_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_53_idx"), "."));
            sGXsfl_53_idx = GetPar( "sGXsfl_53_idx");
            Gx_mode = GetPar( "Mode");
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxnrGridcliente_endereco_newrow( ) ;
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
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
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
               Form.Meta.addItem("generator", "GeneXus C# 17_0_4-151606", 0) ;
            }
            Form.Meta.addItem("description", "Cliente", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtClienteId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cliente( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public cliente( IGxContext context )
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("rwdmasterpage", "GeneXus.Programs.rwdmasterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
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
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "WWAdvancedContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8 col-sm-offset-2", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "TableTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Cliente", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8 col-sm-offset-2", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "FormContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 ToolbarCellClass", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnFirst";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 4, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"CLIENTEID"+"'), id:'"+"CLIENTEID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCellAdvanced", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtClienteId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClienteId_Internalname, "Código", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClienteId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1ClienteId), 4, 0, ",", "")), ((edtClienteId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A1ClienteId), "ZZZ9")) : context.localUtil.Format( (decimal)(A1ClienteId), "ZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtClienteId_Enabled, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtClienteNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClienteNome_Internalname, "Nome", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClienteNome_Internalname, StringUtil.RTrim( A2ClienteNome), StringUtil.RTrim( context.localUtil.Format( A2ClienteNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteNome_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtClienteNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtClienteDocumento_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClienteDocumento_Internalname, "Documento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClienteDocumento_Internalname, StringUtil.RTrim( A3ClienteDocumento), StringUtil.RTrim( context.localUtil.Format( A3ClienteDocumento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteDocumento_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtClienteDocumento_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 LevelTable", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divEnderecotable_Internalname, 1, 0, "px", 0, "px", "LevelTable", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitleendereco_Internalname, "Endereco", "", "", lblTitleendereco_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         gxdraw_Gridcliente_endereco( ) ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group Confirm", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "Center", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void gxdraw_Gridcliente_endereco( )
      {
         /*  Grid Control  */
         Gridcliente_enderecoContainer.AddObjectProperty("GridName", "Gridcliente_endereco");
         Gridcliente_enderecoContainer.AddObjectProperty("Header", subGridcliente_endereco_Header);
         Gridcliente_enderecoContainer.AddObjectProperty("Class", "Grid");
         Gridcliente_enderecoContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridcliente_enderecoContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridcliente_enderecoContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcliente_endereco_Backcolorstyle), 1, 0, ".", "")));
         Gridcliente_enderecoContainer.AddObjectProperty("CmpContext", "");
         Gridcliente_enderecoContainer.AddObjectProperty("InMasterPage", "false");
         Gridcliente_enderecoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridcliente_enderecoColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A4ClienteEnderecoId), 4, 0, ".", "")));
         Gridcliente_enderecoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtClienteEnderecoId_Enabled), 5, 0, ".", "")));
         Gridcliente_enderecoContainer.AddColumnProperties(Gridcliente_enderecoColumn);
         Gridcliente_enderecoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridcliente_enderecoColumn.AddObjectProperty("Value", StringUtil.RTrim( A5ClienteEnderecoEnderecoLogrado));
         Gridcliente_enderecoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtClienteEnderecoEnderecoLogrado_Enabled), 5, 0, ".", "")));
         Gridcliente_enderecoContainer.AddColumnProperties(Gridcliente_enderecoColumn);
         Gridcliente_enderecoContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcliente_endereco_Selectedindex), 4, 0, ".", "")));
         Gridcliente_enderecoContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcliente_endereco_Allowselection), 1, 0, ".", "")));
         Gridcliente_enderecoContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcliente_endereco_Selectioncolor), 9, 0, ".", "")));
         Gridcliente_enderecoContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcliente_endereco_Allowhovering), 1, 0, ".", "")));
         Gridcliente_enderecoContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcliente_endereco_Hoveringcolor), 9, 0, ".", "")));
         Gridcliente_enderecoContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcliente_endereco_Allowcollapsing), 1, 0, ".", "")));
         Gridcliente_enderecoContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcliente_endereco_Collapsed), 1, 0, ".", "")));
         nGXsfl_53_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount2 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_2 = 1;
               ScanStart012( ) ;
               while ( RcdFound2 != 0 )
               {
                  init_level_properties2( ) ;
                  getByPrimaryKey012( ) ;
                  AddRow012( ) ;
                  ScanNext012( ) ;
               }
               ScanEnd012( ) ;
               nBlankRcdCount2 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal012( ) ;
            standaloneModal012( ) ;
            sMode2 = Gx_mode;
            while ( nGXsfl_53_idx < nRC_GXsfl_53 )
            {
               bGXsfl_53_Refreshing = true;
               ReadRow012( ) ;
               edtClienteEnderecoId_Enabled = (int)(context.localUtil.CToN( cgiGet( "CLIENTEENDERECOID_"+sGXsfl_53_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtClienteEnderecoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteEnderecoId_Enabled), 5, 0), !bGXsfl_53_Refreshing);
               edtClienteEnderecoEnderecoLogrado_Enabled = (int)(context.localUtil.CToN( cgiGet( "CLIENTEENDERECOENDERECOLOGRADO_"+sGXsfl_53_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtClienteEnderecoEnderecoLogrado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteEnderecoEnderecoLogrado_Enabled), 5, 0), !bGXsfl_53_Refreshing);
               if ( ( nRcdExists_2 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal012( ) ;
               }
               SendRow012( ) ;
               bGXsfl_53_Refreshing = false;
            }
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount2 = 5;
            nRcdExists_2 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart012( ) ;
               while ( RcdFound2 != 0 )
               {
                  sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_532( ) ;
                  init_level_properties2( ) ;
                  standaloneNotModal012( ) ;
                  getByPrimaryKey012( ) ;
                  standaloneModal012( ) ;
                  AddRow012( ) ;
                  ScanNext012( ) ;
               }
               ScanEnd012( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         sMode2 = Gx_mode;
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx+1), 4, 0), 4, "0");
         SubsflControlProps_532( ) ;
         InitAll012( ) ;
         init_level_properties2( ) ;
         nRcdExists_2 = 0;
         nIsMod_2 = 0;
         nRcdDeleted_2 = 0;
         nBlankRcdCount2 = (short)(nBlankRcdUsr2+nBlankRcdCount2);
         fRowAdded = 0;
         while ( nBlankRcdCount2 > 0 )
         {
            standaloneNotModal012( ) ;
            standaloneModal012( ) ;
            AddRow012( ) ;
            if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
            {
               fRowAdded = 1;
               GX_FocusControl = edtClienteEnderecoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nBlankRcdCount2 = (short)(nBlankRcdCount2-1);
         }
         Gx_mode = sMode2;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridcliente_enderecoContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridcliente_endereco", Gridcliente_enderecoContainer);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridcliente_enderecoContainerData", Gridcliente_enderecoContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridcliente_enderecoContainerData"+"V", Gridcliente_enderecoContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridcliente_enderecoContainerData"+"V"+"\" value='"+Gridcliente_enderecoContainer.GridValuesHidden()+"'/>") ;
         }
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
            Z1ClienteId = (short)(context.localUtil.CToN( cgiGet( "Z1ClienteId"), ",", "."));
            Z2ClienteNome = cgiGet( "Z2ClienteNome");
            Z3ClienteDocumento = cgiGet( "Z3ClienteDocumento");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
            Gx_mode = cgiGet( "Mode");
            nRC_GXsfl_53 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_53"), ",", "."));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLIENTEID");
               AnyError = 1;
               GX_FocusControl = edtClienteId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1ClienteId = 0;
               AssignAttri("", false, "A1ClienteId", StringUtil.LTrimStr( (decimal)(A1ClienteId), 4, 0));
            }
            else
            {
               A1ClienteId = (short)(context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ",", "."));
               AssignAttri("", false, "A1ClienteId", StringUtil.LTrimStr( (decimal)(A1ClienteId), 4, 0));
            }
            A2ClienteNome = cgiGet( edtClienteNome_Internalname);
            AssignAttri("", false, "A2ClienteNome", A2ClienteNome);
            A3ClienteDocumento = cgiGet( edtClienteDocumento_Internalname);
            AssignAttri("", false, "A3ClienteDocumento", A3ClienteDocumento);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               A1ClienteId = (short)(NumberUtil.Val( GetPar( "ClienteId"), "."));
               AssignAttri("", false, "A1ClienteId", StringUtil.LTrimStr( (decimal)(A1ClienteId), 4, 0));
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
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
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
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll011( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
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
         DisableAttributes011( ) ;
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

      protected void CONFIRM_012( )
      {
         nGXsfl_53_idx = 0;
         while ( nGXsfl_53_idx < nRC_GXsfl_53 )
         {
            ReadRow012( ) ;
            if ( ( nRcdExists_2 != 0 ) || ( nIsMod_2 != 0 ) )
            {
               GetKey012( ) ;
               if ( ( nRcdExists_2 == 0 ) && ( nRcdDeleted_2 == 0 ) )
               {
                  if ( RcdFound2 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate012( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable012( ) ;
                        CloseExtendedTableCursors012( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "CLIENTEENDERECOID_" + sGXsfl_53_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtClienteEnderecoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound2 != 0 )
                  {
                     if ( nRcdDeleted_2 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey012( ) ;
                        Load012( ) ;
                        BeforeValidate012( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls012( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_2 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate012( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable012( ) ;
                              CloseExtendedTableCursors012( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_2 == 0 )
                     {
                        GXCCtl = "CLIENTEENDERECOID_" + sGXsfl_53_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtClienteEnderecoId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtClienteEnderecoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A4ClienteEnderecoId), 4, 0, ",", ""))) ;
            ChangePostValue( edtClienteEnderecoEnderecoLogrado_Internalname, StringUtil.RTrim( A5ClienteEnderecoEnderecoLogrado)) ;
            ChangePostValue( "ZT_"+"Z4ClienteEnderecoId_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z4ClienteEnderecoId), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z5ClienteEnderecoEnderecoLogrado_"+sGXsfl_53_idx, StringUtil.RTrim( Z5ClienteEnderecoEnderecoLogrado)) ;
            ChangePostValue( "nRcdDeleted_2_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_2), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_2_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_2), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_2_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_2), 4, 0, ",", ""))) ;
            if ( nIsMod_2 != 0 )
            {
               ChangePostValue( "CLIENTEENDERECOID_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtClienteEnderecoId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CLIENTEENDERECOENDERECOLOGRADO_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtClienteEnderecoEnderecoLogrado_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption010( )
      {
      }

      protected void ZM011( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2ClienteNome = T00015_A2ClienteNome[0];
               Z3ClienteDocumento = T00015_A3ClienteDocumento[0];
            }
            else
            {
               Z2ClienteNome = A2ClienteNome;
               Z3ClienteDocumento = A3ClienteDocumento;
            }
         }
         if ( GX_JID == -1 )
         {
            Z1ClienteId = A1ClienteId;
            Z2ClienteNome = A2ClienteNome;
            Z3ClienteDocumento = A3ClienteDocumento;
         }
      }

      protected void standaloneNotModal( )
      {
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

      protected void Load011( )
      {
         /* Using cursor T00016 */
         pr_default.execute(4, new Object[] {A1ClienteId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound1 = 1;
            A2ClienteNome = T00016_A2ClienteNome[0];
            AssignAttri("", false, "A2ClienteNome", A2ClienteNome);
            A3ClienteDocumento = T00016_A3ClienteDocumento[0];
            AssignAttri("", false, "A3ClienteDocumento", A3ClienteDocumento);
            ZM011( -1) ;
         }
         pr_default.close(4);
         OnLoadActions011( ) ;
      }

      protected void OnLoadActions011( )
      {
      }

      protected void CheckExtendedTable011( )
      {
         nIsDirty_1 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors011( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey011( )
      {
         /* Using cursor T00017 */
         pr_default.execute(5, new Object[] {A1ClienteId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound1 = 1;
         }
         else
         {
            RcdFound1 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00015 */
         pr_default.execute(3, new Object[] {A1ClienteId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM011( 1) ;
            RcdFound1 = 1;
            A1ClienteId = T00015_A1ClienteId[0];
            AssignAttri("", false, "A1ClienteId", StringUtil.LTrimStr( (decimal)(A1ClienteId), 4, 0));
            A2ClienteNome = T00015_A2ClienteNome[0];
            AssignAttri("", false, "A2ClienteNome", A2ClienteNome);
            A3ClienteDocumento = T00015_A3ClienteDocumento[0];
            AssignAttri("", false, "A3ClienteDocumento", A3ClienteDocumento);
            Z1ClienteId = A1ClienteId;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load011( ) ;
            if ( AnyError == 1 )
            {
               RcdFound1 = 0;
               InitializeNonKey011( ) ;
            }
            Gx_mode = sMode1;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound1 = 0;
            InitializeNonKey011( ) ;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode1;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey011( ) ;
         if ( RcdFound1 == 0 )
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
         RcdFound1 = 0;
         /* Using cursor T00018 */
         pr_default.execute(6, new Object[] {A1ClienteId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00018_A1ClienteId[0] < A1ClienteId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00018_A1ClienteId[0] > A1ClienteId ) ) )
            {
               A1ClienteId = T00018_A1ClienteId[0];
               AssignAttri("", false, "A1ClienteId", StringUtil.LTrimStr( (decimal)(A1ClienteId), 4, 0));
               RcdFound1 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound1 = 0;
         /* Using cursor T00019 */
         pr_default.execute(7, new Object[] {A1ClienteId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00019_A1ClienteId[0] > A1ClienteId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00019_A1ClienteId[0] < A1ClienteId ) ) )
            {
               A1ClienteId = T00019_A1ClienteId[0];
               AssignAttri("", false, "A1ClienteId", StringUtil.LTrimStr( (decimal)(A1ClienteId), 4, 0));
               RcdFound1 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey011( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtClienteId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert011( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound1 == 1 )
            {
               if ( A1ClienteId != Z1ClienteId )
               {
                  A1ClienteId = Z1ClienteId;
                  AssignAttri("", false, "A1ClienteId", StringUtil.LTrimStr( (decimal)(A1ClienteId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CLIENTEID");
                  AnyError = 1;
                  GX_FocusControl = edtClienteId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtClienteId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update011( ) ;
                  GX_FocusControl = edtClienteId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A1ClienteId != Z1ClienteId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtClienteId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert011( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CLIENTEID");
                     AnyError = 1;
                     GX_FocusControl = edtClienteId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtClienteId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert011( ) ;
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
         if ( A1ClienteId != Z1ClienteId )
         {
            A1ClienteId = Z1ClienteId;
            AssignAttri("", false, "A1ClienteId", StringUtil.LTrimStr( (decimal)(A1ClienteId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CLIENTEID");
            AnyError = 1;
            GX_FocusControl = edtClienteId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtClienteId_Internalname;
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
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CLIENTEID");
            AnyError = 1;
            GX_FocusControl = edtClienteId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtClienteNome_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart011( ) ;
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtClienteNome_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd011( ) ;
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
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtClienteNome_Internalname;
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
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtClienteNome_Internalname;
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
         ScanStart011( ) ;
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound1 != 0 )
            {
               ScanNext011( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtClienteNome_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd011( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency011( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00014 */
            pr_default.execute(2, new Object[] {A1ClienteId});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Cliente"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z2ClienteNome, T00014_A2ClienteNome[0]) != 0 ) || ( StringUtil.StrCmp(Z3ClienteDocumento, T00014_A3ClienteDocumento[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z2ClienteNome, T00014_A2ClienteNome[0]) != 0 )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ClienteNome");
                  GXUtil.WriteLogRaw("Old: ",Z2ClienteNome);
                  GXUtil.WriteLogRaw("Current: ",T00014_A2ClienteNome[0]);
               }
               if ( StringUtil.StrCmp(Z3ClienteDocumento, T00014_A3ClienteDocumento[0]) != 0 )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ClienteDocumento");
                  GXUtil.WriteLogRaw("Old: ",Z3ClienteDocumento);
                  GXUtil.WriteLogRaw("Current: ",T00014_A3ClienteDocumento[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Cliente"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM011( 0) ;
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000110 */
                     pr_default.execute(8, new Object[] {A1ClienteId, A2ClienteNome, A3ClienteDocumento});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("Cliente");
                     if ( (pr_default.getStatus(8) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel011( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption010( ) ;
                           }
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
               Load011( ) ;
            }
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void Update011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000111 */
                     pr_default.execute(9, new Object[] {A2ClienteNome, A3ClienteDocumento, A1ClienteId});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("Cliente");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Cliente"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate011( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel011( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
                              ResetCaption010( ) ;
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
            }
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void DeferredUpdate011( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls011( ) ;
            AfterConfirm011( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete011( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart012( ) ;
                  while ( RcdFound2 != 0 )
                  {
                     getByPrimaryKey012( ) ;
                     Delete012( ) ;
                     ScanNext012( ) ;
                  }
                  ScanEnd012( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000112 */
                     pr_default.execute(10, new Object[] {A1ClienteId});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("Cliente");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           move_next( ) ;
                           if ( RcdFound1 == 0 )
                           {
                              InitAll011( ) ;
                              Gx_mode = "INS";
                              AssignAttri("", false, "Gx_mode", Gx_mode);
                           }
                           else
                           {
                              getByPrimaryKey( ) ;
                              Gx_mode = "UPD";
                              AssignAttri("", false, "Gx_mode", Gx_mode);
                           }
                           endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                           endTrnMsgCod = "SuccessfullyDeleted";
                           ResetCaption010( ) ;
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
         }
         sMode1 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel011( ) ;
         Gx_mode = sMode1;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls011( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void ProcessNestedLevel012( )
      {
         nGXsfl_53_idx = 0;
         while ( nGXsfl_53_idx < nRC_GXsfl_53 )
         {
            ReadRow012( ) ;
            if ( ( nRcdExists_2 != 0 ) || ( nIsMod_2 != 0 ) )
            {
               standaloneNotModal012( ) ;
               GetKey012( ) ;
               if ( ( nRcdExists_2 == 0 ) && ( nRcdDeleted_2 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert012( ) ;
               }
               else
               {
                  if ( RcdFound2 != 0 )
                  {
                     if ( ( nRcdDeleted_2 != 0 ) && ( nRcdExists_2 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete012( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_2 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update012( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_2 == 0 )
                     {
                        GXCCtl = "CLIENTEENDERECOID_" + sGXsfl_53_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtClienteEnderecoId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtClienteEnderecoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A4ClienteEnderecoId), 4, 0, ",", ""))) ;
            ChangePostValue( edtClienteEnderecoEnderecoLogrado_Internalname, StringUtil.RTrim( A5ClienteEnderecoEnderecoLogrado)) ;
            ChangePostValue( "ZT_"+"Z4ClienteEnderecoId_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z4ClienteEnderecoId), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z5ClienteEnderecoEnderecoLogrado_"+sGXsfl_53_idx, StringUtil.RTrim( Z5ClienteEnderecoEnderecoLogrado)) ;
            ChangePostValue( "nRcdDeleted_2_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_2), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_2_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_2), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_2_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_2), 4, 0, ",", ""))) ;
            if ( nIsMod_2 != 0 )
            {
               ChangePostValue( "CLIENTEENDERECOID_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtClienteEnderecoId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CLIENTEENDERECOENDERECOLOGRADO_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtClienteEnderecoEnderecoLogrado_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll012( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_2 = 0;
         nIsMod_2 = 0;
         nRcdDeleted_2 = 0;
      }

      protected void ProcessLevel011( )
      {
         /* Save parent mode. */
         sMode1 = Gx_mode;
         ProcessNestedLevel012( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode1;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel011( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete011( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            context.CommitDataStores("cliente",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues010( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            context.RollbackDataStores("cliente",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart011( )
      {
         /* Using cursor T000113 */
         pr_default.execute(11);
         RcdFound1 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound1 = 1;
            A1ClienteId = T000113_A1ClienteId[0];
            AssignAttri("", false, "A1ClienteId", StringUtil.LTrimStr( (decimal)(A1ClienteId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext011( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound1 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound1 = 1;
            A1ClienteId = T000113_A1ClienteId[0];
            AssignAttri("", false, "A1ClienteId", StringUtil.LTrimStr( (decimal)(A1ClienteId), 4, 0));
         }
      }

      protected void ScanEnd011( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm011( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert011( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate011( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete011( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete011( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate011( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes011( )
      {
         edtClienteId_Enabled = 0;
         AssignProp("", false, edtClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteId_Enabled), 5, 0), true);
         edtClienteNome_Enabled = 0;
         AssignProp("", false, edtClienteNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteNome_Enabled), 5, 0), true);
         edtClienteDocumento_Enabled = 0;
         AssignProp("", false, edtClienteDocumento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteDocumento_Enabled), 5, 0), true);
      }

      protected void ZM012( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z5ClienteEnderecoEnderecoLogrado = T00013_A5ClienteEnderecoEnderecoLogrado[0];
            }
            else
            {
               Z5ClienteEnderecoEnderecoLogrado = A5ClienteEnderecoEnderecoLogrado;
            }
         }
         if ( GX_JID == -2 )
         {
            Z1ClienteId = A1ClienteId;
            Z4ClienteEnderecoId = A4ClienteEnderecoId;
            Z5ClienteEnderecoEnderecoLogrado = A5ClienteEnderecoEnderecoLogrado;
         }
      }

      protected void standaloneNotModal012( )
      {
      }

      protected void standaloneModal012( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtClienteEnderecoId_Enabled = 0;
            AssignProp("", false, edtClienteEnderecoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteEnderecoId_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         }
         else
         {
            edtClienteEnderecoId_Enabled = 1;
            AssignProp("", false, edtClienteEnderecoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteEnderecoId_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         }
      }

      protected void Load012( )
      {
         /* Using cursor T000114 */
         pr_default.execute(12, new Object[] {A1ClienteId, A4ClienteEnderecoId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound2 = 1;
            A5ClienteEnderecoEnderecoLogrado = T000114_A5ClienteEnderecoEnderecoLogrado[0];
            ZM012( -2) ;
         }
         pr_default.close(12);
         OnLoadActions012( ) ;
      }

      protected void OnLoadActions012( )
      {
      }

      protected void CheckExtendedTable012( )
      {
         nIsDirty_2 = 0;
         Gx_BScreen = 1;
         standaloneModal012( ) ;
      }

      protected void CloseExtendedTableCursors012( )
      {
      }

      protected void enableDisable012( )
      {
      }

      protected void GetKey012( )
      {
         /* Using cursor T000115 */
         pr_default.execute(13, new Object[] {A1ClienteId, A4ClienteEnderecoId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound2 = 1;
         }
         else
         {
            RcdFound2 = 0;
         }
         pr_default.close(13);
      }

      protected void getByPrimaryKey012( )
      {
         /* Using cursor T00013 */
         pr_default.execute(1, new Object[] {A1ClienteId, A4ClienteEnderecoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM012( 2) ;
            RcdFound2 = 1;
            InitializeNonKey012( ) ;
            A4ClienteEnderecoId = T00013_A4ClienteEnderecoId[0];
            A5ClienteEnderecoEnderecoLogrado = T00013_A5ClienteEnderecoEnderecoLogrado[0];
            Z1ClienteId = A1ClienteId;
            Z4ClienteEnderecoId = A4ClienteEnderecoId;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal012( ) ;
            Load012( ) ;
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound2 = 0;
            InitializeNonKey012( ) ;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal012( ) ;
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes012( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency012( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00012 */
            pr_default.execute(0, new Object[] {A1ClienteId, A4ClienteEnderecoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ClienteEndereco"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z5ClienteEnderecoEnderecoLogrado, T00012_A5ClienteEnderecoEnderecoLogrado[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z5ClienteEnderecoEnderecoLogrado, T00012_A5ClienteEnderecoEnderecoLogrado[0]) != 0 )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ClienteEnderecoEnderecoLogrado");
                  GXUtil.WriteLogRaw("Old: ",Z5ClienteEnderecoEnderecoLogrado);
                  GXUtil.WriteLogRaw("Current: ",T00012_A5ClienteEnderecoEnderecoLogrado[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ClienteEndereco"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert012( )
      {
         BeforeValidate012( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable012( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM012( 0) ;
            CheckOptimisticConcurrency012( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm012( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert012( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000116 */
                     pr_default.execute(14, new Object[] {A1ClienteId, A4ClienteEnderecoId, A5ClienteEnderecoEnderecoLogrado});
                     pr_default.close(14);
                     dsDefault.SmartCacheProvider.SetUpdated("ClienteEndereco");
                     if ( (pr_default.getStatus(14) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
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
               Load012( ) ;
            }
            EndLevel012( ) ;
         }
         CloseExtendedTableCursors012( ) ;
      }

      protected void Update012( )
      {
         BeforeValidate012( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable012( ) ;
         }
         if ( ( nIsMod_2 != 0 ) || ( nIsDirty_2 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency012( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm012( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate012( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000117 */
                        pr_default.execute(15, new Object[] {A5ClienteEnderecoEnderecoLogrado, A1ClienteId, A4ClienteEnderecoId});
                        pr_default.close(15);
                        dsDefault.SmartCacheProvider.SetUpdated("ClienteEndereco");
                        if ( (pr_default.getStatus(15) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ClienteEndereco"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate012( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey012( ) ;
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
               EndLevel012( ) ;
            }
         }
         CloseExtendedTableCursors012( ) ;
      }

      protected void DeferredUpdate012( )
      {
      }

      protected void Delete012( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate012( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency012( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls012( ) ;
            AfterConfirm012( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete012( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000118 */
                  pr_default.execute(16, new Object[] {A1ClienteId, A4ClienteEnderecoId});
                  pr_default.close(16);
                  dsDefault.SmartCacheProvider.SetUpdated("ClienteEndereco");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode2 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel012( ) ;
         Gx_mode = sMode2;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls012( )
      {
         standaloneModal012( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel012( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart012( )
      {
         /* Scan By routine */
         /* Using cursor T000119 */
         pr_default.execute(17, new Object[] {A1ClienteId});
         RcdFound2 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound2 = 1;
            A4ClienteEnderecoId = T000119_A4ClienteEnderecoId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext012( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound2 = 1;
            A4ClienteEnderecoId = T000119_A4ClienteEnderecoId[0];
         }
      }

      protected void ScanEnd012( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm012( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert012( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate012( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete012( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete012( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate012( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes012( )
      {
         edtClienteEnderecoId_Enabled = 0;
         AssignProp("", false, edtClienteEnderecoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteEnderecoId_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         edtClienteEnderecoEnderecoLogrado_Enabled = 0;
         AssignProp("", false, edtClienteEnderecoEnderecoLogrado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteEnderecoEnderecoLogrado_Enabled), 5, 0), !bGXsfl_53_Refreshing);
      }

      protected void send_integrity_lvl_hashes012( )
      {
      }

      protected void send_integrity_lvl_hashes011( )
      {
      }

      protected void SubsflControlProps_532( )
      {
         edtClienteEnderecoId_Internalname = "CLIENTEENDERECOID_"+sGXsfl_53_idx;
         edtClienteEnderecoEnderecoLogrado_Internalname = "CLIENTEENDERECOENDERECOLOGRADO_"+sGXsfl_53_idx;
      }

      protected void SubsflControlProps_fel_532( )
      {
         edtClienteEnderecoId_Internalname = "CLIENTEENDERECOID_"+sGXsfl_53_fel_idx;
         edtClienteEnderecoEnderecoLogrado_Internalname = "CLIENTEENDERECOENDERECOLOGRADO_"+sGXsfl_53_fel_idx;
      }

      protected void AddRow012( )
      {
         nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
         sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
         SubsflControlProps_532( ) ;
         SendRow012( ) ;
      }

      protected void SendRow012( )
      {
         Gridcliente_enderecoRow = GXWebRow.GetNew(context);
         if ( subGridcliente_endereco_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridcliente_endereco_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridcliente_endereco_Class, "") != 0 )
            {
               subGridcliente_endereco_Linesclass = subGridcliente_endereco_Class+"Odd";
            }
         }
         else if ( subGridcliente_endereco_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridcliente_endereco_Backstyle = 0;
            subGridcliente_endereco_Backcolor = subGridcliente_endereco_Allbackcolor;
            if ( StringUtil.StrCmp(subGridcliente_endereco_Class, "") != 0 )
            {
               subGridcliente_endereco_Linesclass = subGridcliente_endereco_Class+"Uniform";
            }
         }
         else if ( subGridcliente_endereco_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridcliente_endereco_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridcliente_endereco_Class, "") != 0 )
            {
               subGridcliente_endereco_Linesclass = subGridcliente_endereco_Class+"Odd";
            }
            subGridcliente_endereco_Backcolor = (int)(0x0);
         }
         else if ( subGridcliente_endereco_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridcliente_endereco_Backstyle = 1;
            if ( ((int)((nGXsfl_53_idx) % (2))) == 0 )
            {
               subGridcliente_endereco_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridcliente_endereco_Class, "") != 0 )
               {
                  subGridcliente_endereco_Linesclass = subGridcliente_endereco_Class+"Even";
               }
            }
            else
            {
               subGridcliente_endereco_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridcliente_endereco_Class, "") != 0 )
               {
                  subGridcliente_endereco_Linesclass = subGridcliente_endereco_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_2_" + sGXsfl_53_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 54,'',false,'" + sGXsfl_53_idx + "',53)\"";
         ROClassString = "Attribute";
         Gridcliente_enderecoRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteEnderecoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A4ClienteEnderecoId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A4ClienteEnderecoId), "ZZZ9")),TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,54);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteEnderecoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtClienteEnderecoId_Enabled,(short)1,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)53,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_2_" + sGXsfl_53_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 55,'',false,'" + sGXsfl_53_idx + "',53)\"";
         ROClassString = "Attribute";
         Gridcliente_enderecoRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteEnderecoEnderecoLogrado_Internalname,StringUtil.RTrim( A5ClienteEnderecoEnderecoLogrado),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteEnderecoEnderecoLogrado_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtClienteEnderecoEnderecoLogrado_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)53,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         context.httpAjaxContext.ajax_sending_grid_row(Gridcliente_enderecoRow);
         send_integrity_lvl_hashes012( ) ;
         GXCCtl = "Z4ClienteEnderecoId_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z4ClienteEnderecoId), 4, 0, ",", "")));
         GXCCtl = "Z5ClienteEnderecoEnderecoLogrado_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z5ClienteEnderecoEnderecoLogrado));
         GXCCtl = "nRcdDeleted_2_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_2), 4, 0, ",", "")));
         GXCCtl = "nRcdExists_2_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_2), 4, 0, ",", "")));
         GXCCtl = "nIsMod_2_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CLIENTEENDERECOID_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtClienteEnderecoId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CLIENTEENDERECOENDERECOLOGRADO_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtClienteEnderecoEnderecoLogrado_Enabled), 5, 0, ".", "")));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridcliente_enderecoContainer.AddRow(Gridcliente_enderecoRow);
      }

      protected void ReadRow012( )
      {
         nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
         sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
         SubsflControlProps_532( ) ;
         edtClienteEnderecoId_Enabled = (int)(context.localUtil.CToN( cgiGet( "CLIENTEENDERECOID_"+sGXsfl_53_idx+"Enabled"), ",", "."));
         edtClienteEnderecoEnderecoLogrado_Enabled = (int)(context.localUtil.CToN( cgiGet( "CLIENTEENDERECOENDERECOLOGRADO_"+sGXsfl_53_idx+"Enabled"), ",", "."));
         if ( ( ( context.localUtil.CToN( cgiGet( edtClienteEnderecoId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtClienteEnderecoId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "CLIENTEENDERECOID_" + sGXsfl_53_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtClienteEnderecoId_Internalname;
            wbErr = true;
            A4ClienteEnderecoId = 0;
         }
         else
         {
            A4ClienteEnderecoId = (short)(context.localUtil.CToN( cgiGet( edtClienteEnderecoId_Internalname), ",", "."));
         }
         A5ClienteEnderecoEnderecoLogrado = cgiGet( edtClienteEnderecoEnderecoLogrado_Internalname);
         GXCCtl = "Z4ClienteEnderecoId_" + sGXsfl_53_idx;
         Z4ClienteEnderecoId = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         GXCCtl = "Z5ClienteEnderecoEnderecoLogrado_" + sGXsfl_53_idx;
         Z5ClienteEnderecoEnderecoLogrado = cgiGet( GXCCtl);
         GXCCtl = "nRcdDeleted_2_" + sGXsfl_53_idx;
         nRcdDeleted_2 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         GXCCtl = "nRcdExists_2_" + sGXsfl_53_idx;
         nRcdExists_2 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         GXCCtl = "nIsMod_2_" + sGXsfl_53_idx;
         nIsMod_2 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
      }

      protected void assign_properties_default( )
      {
         defedtClienteEnderecoId_Enabled = edtClienteEnderecoId_Enabled;
      }

      protected void ConfirmValues010( )
      {
         nGXsfl_53_idx = 0;
         sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
         SubsflControlProps_532( ) ;
         while ( nGXsfl_53_idx < nRC_GXsfl_53 )
         {
            nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
            sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
            SubsflControlProps_532( ) ;
            ChangePostValue( "Z4ClienteEnderecoId_"+sGXsfl_53_idx, cgiGet( "ZT_"+"Z4ClienteEnderecoId_"+sGXsfl_53_idx)) ;
            DeletePostValue( "ZT_"+"Z4ClienteEnderecoId_"+sGXsfl_53_idx) ;
            ChangePostValue( "Z5ClienteEnderecoEnderecoLogrado_"+sGXsfl_53_idx, cgiGet( "ZT_"+"Z5ClienteEnderecoEnderecoLogrado_"+sGXsfl_53_idx)) ;
            DeletePostValue( "ZT_"+"Z5ClienteEnderecoEnderecoLogrado_"+sGXsfl_53_idx) ;
         }
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
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 348140), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 348140), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 348140), false, true);
         context.AddJavascriptSource("gxcfg.js", "?20217221934090", false, true);
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
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("cliente.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z1ClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1ClienteId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z2ClienteNome", StringUtil.RTrim( Z2ClienteNome));
         GxWebStd.gx_hidden_field( context, "Z3ClienteDocumento", StringUtil.RTrim( Z3ClienteDocumento));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_53", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_53_idx), 8, 0, ",", "")));
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

      public override string GetSelfLink( )
      {
         return formatLink("cliente.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Cliente" ;
      }

      public override string GetPgmdesc( )
      {
         return "Cliente" ;
      }

      protected void InitializeNonKey011( )
      {
         A2ClienteNome = "";
         AssignAttri("", false, "A2ClienteNome", A2ClienteNome);
         A3ClienteDocumento = "";
         AssignAttri("", false, "A3ClienteDocumento", A3ClienteDocumento);
         Z2ClienteNome = "";
         Z3ClienteDocumento = "";
      }

      protected void InitAll011( )
      {
         A1ClienteId = 0;
         AssignAttri("", false, "A1ClienteId", StringUtil.LTrimStr( (decimal)(A1ClienteId), 4, 0));
         InitializeNonKey011( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey012( )
      {
         A5ClienteEnderecoEnderecoLogrado = "";
         Z5ClienteEnderecoEnderecoLogrado = "";
      }

      protected void InitAll012( )
      {
         A4ClienteEnderecoId = 0;
         InitializeNonKey012( ) ;
      }

      protected void StandaloneModalInsert012( )
      {
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20217221934092", true, true);
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
         context.AddJavascriptSource("messages.por.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("cliente.js", "?20217221934092", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties2( )
      {
         edtClienteEnderecoId_Enabled = defedtClienteEnderecoId_Enabled;
         AssignProp("", false, edtClienteEnderecoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteEnderecoId_Enabled), 5, 0), !bGXsfl_53_Refreshing);
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtClienteId_Internalname = "CLIENTEID";
         edtClienteNome_Internalname = "CLIENTENOME";
         edtClienteDocumento_Internalname = "CLIENTEDOCUMENTO";
         lblTitleendereco_Internalname = "TITLEENDERECO";
         edtClienteEnderecoId_Internalname = "CLIENTEENDERECOID";
         edtClienteEnderecoEnderecoLogrado_Internalname = "CLIENTEENDERECOENDERECOLOGRADO";
         divEnderecotable_Internalname = "ENDERECOTABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGridcliente_endereco_Internalname = "GRIDCLIENTE_ENDERECO";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Carmine");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Cliente";
         edtClienteEnderecoEnderecoLogrado_Jsonclick = "";
         edtClienteEnderecoId_Jsonclick = "";
         subGridcliente_endereco_Class = "Grid";
         subGridcliente_endereco_Backcolorstyle = 0;
         subGridcliente_endereco_Allowcollapsing = 0;
         subGridcliente_endereco_Allowselection = 0;
         edtClienteEnderecoEnderecoLogrado_Enabled = 1;
         edtClienteEnderecoId_Enabled = 1;
         subGridcliente_endereco_Header = "";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtClienteDocumento_Jsonclick = "";
         edtClienteDocumento_Enabled = 1;
         edtClienteNome_Jsonclick = "";
         edtClienteNome_Enabled = 1;
         edtClienteId_Jsonclick = "";
         edtClienteId_Enabled = 1;
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

      protected void gxnrGridcliente_endereco_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_532( ) ;
         while ( nGXsfl_53_idx <= nRC_GXsfl_53 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal012( ) ;
            standaloneModal012( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow012( ) ;
            nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
            sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
            SubsflControlProps_532( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridcliente_enderecoContainer)) ;
         /* End function gxnrGridcliente_endereco_newrow */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtClienteNome_Internalname;
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

      public void Valid_Clienteid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2ClienteNome", StringUtil.RTrim( A2ClienteNome));
         AssignAttri("", false, "A3ClienteDocumento", StringUtil.RTrim( A3ClienteDocumento));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z1ClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1ClienteId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2ClienteNome", StringUtil.RTrim( Z2ClienteNome));
         GxWebStd.gx_hidden_field( context, "Z3ClienteDocumento", StringUtil.RTrim( Z3ClienteDocumento));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
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
         setEventMetadata("VALID_CLIENTEID","{handler:'Valid_Clienteid',iparms:[{av:'A1ClienteId',fld:'CLIENTEID',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_CLIENTEID",",oparms:[{av:'A2ClienteNome',fld:'CLIENTENOME',pic:''},{av:'A3ClienteDocumento',fld:'CLIENTEDOCUMENTO',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z1ClienteId'},{av:'Z2ClienteNome'},{av:'Z3ClienteDocumento'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_CLIENTEENDERECOID","{handler:'Valid_Clienteenderecoid',iparms:[]");
         setEventMetadata("VALID_CLIENTEENDERECOID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Clienteenderecoenderecologrado',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         return  ;
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
         pr_default.close(1);
         pr_default.close(3);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z2ClienteNome = "";
         Z3ClienteDocumento = "";
         Z5ClienteEnderecoEnderecoLogrado = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         Gx_mode = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A2ClienteNome = "";
         A3ClienteDocumento = "";
         lblTitleendereco_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridcliente_enderecoContainer = new GXWebGrid( context);
         Gridcliente_enderecoColumn = new GXWebColumn();
         A5ClienteEnderecoEnderecoLogrado = "";
         sMode2 = "";
         sStyleString = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         T00016_A1ClienteId = new short[1] ;
         T00016_A2ClienteNome = new string[] {""} ;
         T00016_A3ClienteDocumento = new string[] {""} ;
         T00017_A1ClienteId = new short[1] ;
         T00015_A1ClienteId = new short[1] ;
         T00015_A2ClienteNome = new string[] {""} ;
         T00015_A3ClienteDocumento = new string[] {""} ;
         sMode1 = "";
         T00018_A1ClienteId = new short[1] ;
         T00019_A1ClienteId = new short[1] ;
         T00014_A1ClienteId = new short[1] ;
         T00014_A2ClienteNome = new string[] {""} ;
         T00014_A3ClienteDocumento = new string[] {""} ;
         T000113_A1ClienteId = new short[1] ;
         T000114_A1ClienteId = new short[1] ;
         T000114_A4ClienteEnderecoId = new short[1] ;
         T000114_A5ClienteEnderecoEnderecoLogrado = new string[] {""} ;
         T000115_A1ClienteId = new short[1] ;
         T000115_A4ClienteEnderecoId = new short[1] ;
         T00013_A1ClienteId = new short[1] ;
         T00013_A4ClienteEnderecoId = new short[1] ;
         T00013_A5ClienteEnderecoEnderecoLogrado = new string[] {""} ;
         T00012_A1ClienteId = new short[1] ;
         T00012_A4ClienteEnderecoId = new short[1] ;
         T00012_A5ClienteEnderecoEnderecoLogrado = new string[] {""} ;
         T000119_A1ClienteId = new short[1] ;
         T000119_A4ClienteEnderecoId = new short[1] ;
         Gridcliente_enderecoRow = new GXWebRow();
         subGridcliente_endereco_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ2ClienteNome = "";
         ZZ3ClienteDocumento = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cliente__default(),
            new Object[][] {
                new Object[] {
               T00012_A1ClienteId, T00012_A4ClienteEnderecoId, T00012_A5ClienteEnderecoEnderecoLogrado
               }
               , new Object[] {
               T00013_A1ClienteId, T00013_A4ClienteEnderecoId, T00013_A5ClienteEnderecoEnderecoLogrado
               }
               , new Object[] {
               T00014_A1ClienteId, T00014_A2ClienteNome, T00014_A3ClienteDocumento
               }
               , new Object[] {
               T00015_A1ClienteId, T00015_A2ClienteNome, T00015_A3ClienteDocumento
               }
               , new Object[] {
               T00016_A1ClienteId, T00016_A2ClienteNome, T00016_A3ClienteDocumento
               }
               , new Object[] {
               T00017_A1ClienteId
               }
               , new Object[] {
               T00018_A1ClienteId
               }
               , new Object[] {
               T00019_A1ClienteId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000113_A1ClienteId
               }
               , new Object[] {
               T000114_A1ClienteId, T000114_A4ClienteEnderecoId, T000114_A5ClienteEnderecoEnderecoLogrado
               }
               , new Object[] {
               T000115_A1ClienteId, T000115_A4ClienteEnderecoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000119_A1ClienteId, T000119_A4ClienteEnderecoId
               }
            }
         );
      }

      private short Z1ClienteId ;
      private short Z4ClienteEnderecoId ;
      private short nRcdDeleted_2 ;
      private short nRcdExists_2 ;
      private short nIsMod_2 ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1ClienteId ;
      private short subGridcliente_endereco_Backcolorstyle ;
      private short A4ClienteEnderecoId ;
      private short subGridcliente_endereco_Allowselection ;
      private short subGridcliente_endereco_Allowhovering ;
      private short subGridcliente_endereco_Allowcollapsing ;
      private short subGridcliente_endereco_Collapsed ;
      private short nBlankRcdCount2 ;
      private short RcdFound2 ;
      private short nBlankRcdUsr2 ;
      private short GX_JID ;
      private short RcdFound1 ;
      private short nIsDirty_1 ;
      private short Gx_BScreen ;
      private short nIsDirty_2 ;
      private short subGridcliente_endereco_Backstyle ;
      private short gxajaxcallmode ;
      private short ZZ1ClienteId ;
      private int nRC_GXsfl_53 ;
      private int nGXsfl_53_idx=1 ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtClienteId_Enabled ;
      private int edtClienteNome_Enabled ;
      private int edtClienteDocumento_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtClienteEnderecoId_Enabled ;
      private int edtClienteEnderecoEnderecoLogrado_Enabled ;
      private int subGridcliente_endereco_Selectedindex ;
      private int subGridcliente_endereco_Selectioncolor ;
      private int subGridcliente_endereco_Hoveringcolor ;
      private int fRowAdded ;
      private int subGridcliente_endereco_Backcolor ;
      private int subGridcliente_endereco_Allbackcolor ;
      private int defedtClienteEnderecoId_Enabled ;
      private int idxLst ;
      private long GRIDCLIENTE_ENDERECO_nFirstRecordOnPage ;
      private string sPrefix ;
      private string Z2ClienteNome ;
      private string Z3ClienteDocumento ;
      private string Z5ClienteEnderecoEnderecoLogrado ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_53_idx="0001" ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtClienteId_Internalname ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divFormcontainer_Internalname ;
      private string divToolbarcell_Internalname ;
      private string TempTags ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string edtClienteId_Jsonclick ;
      private string edtClienteNome_Internalname ;
      private string A2ClienteNome ;
      private string edtClienteNome_Jsonclick ;
      private string edtClienteDocumento_Internalname ;
      private string A3ClienteDocumento ;
      private string edtClienteDocumento_Jsonclick ;
      private string divEnderecotable_Internalname ;
      private string lblTitleendereco_Internalname ;
      private string lblTitleendereco_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string subGridcliente_endereco_Header ;
      private string A5ClienteEnderecoEnderecoLogrado ;
      private string sMode2 ;
      private string edtClienteEnderecoId_Internalname ;
      private string edtClienteEnderecoEnderecoLogrado_Internalname ;
      private string sStyleString ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string sMode1 ;
      private string sGXsfl_53_fel_idx="0001" ;
      private string subGridcliente_endereco_Class ;
      private string subGridcliente_endereco_Linesclass ;
      private string ROClassString ;
      private string edtClienteEnderecoId_Jsonclick ;
      private string edtClienteEnderecoEnderecoLogrado_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridcliente_endereco_Internalname ;
      private string ZZ2ClienteNome ;
      private string ZZ3ClienteDocumento ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool bGXsfl_53_Refreshing=false ;
      private GXWebGrid Gridcliente_enderecoContainer ;
      private GXWebRow Gridcliente_enderecoRow ;
      private GXWebColumn Gridcliente_enderecoColumn ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T00016_A1ClienteId ;
      private string[] T00016_A2ClienteNome ;
      private string[] T00016_A3ClienteDocumento ;
      private short[] T00017_A1ClienteId ;
      private short[] T00015_A1ClienteId ;
      private string[] T00015_A2ClienteNome ;
      private string[] T00015_A3ClienteDocumento ;
      private short[] T00018_A1ClienteId ;
      private short[] T00019_A1ClienteId ;
      private short[] T00014_A1ClienteId ;
      private string[] T00014_A2ClienteNome ;
      private string[] T00014_A3ClienteDocumento ;
      private short[] T000113_A1ClienteId ;
      private short[] T000114_A1ClienteId ;
      private short[] T000114_A4ClienteEnderecoId ;
      private string[] T000114_A5ClienteEnderecoEnderecoLogrado ;
      private short[] T000115_A1ClienteId ;
      private short[] T000115_A4ClienteEnderecoId ;
      private short[] T00013_A1ClienteId ;
      private short[] T00013_A4ClienteEnderecoId ;
      private string[] T00013_A5ClienteEnderecoEnderecoLogrado ;
      private short[] T00012_A1ClienteId ;
      private short[] T00012_A4ClienteEnderecoId ;
      private string[] T00012_A5ClienteEnderecoEnderecoLogrado ;
      private short[] T000119_A1ClienteId ;
      private short[] T000119_A4ClienteEnderecoId ;
      private GXWebForm Form ;
   }

   public class cliente__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[8])
         ,new UpdateCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new UpdateCursor(def[14])
         ,new UpdateCursor(def[15])
         ,new UpdateCursor(def[16])
         ,new ForEachCursor(def[17])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00016;
          prmT00016 = new Object[] {
          new ParDef("@ClienteId",GXType.Int16,4,0)
          };
          Object[] prmT00017;
          prmT00017 = new Object[] {
          new ParDef("@ClienteId",GXType.Int16,4,0)
          };
          Object[] prmT00015;
          prmT00015 = new Object[] {
          new ParDef("@ClienteId",GXType.Int16,4,0)
          };
          Object[] prmT00018;
          prmT00018 = new Object[] {
          new ParDef("@ClienteId",GXType.Int16,4,0)
          };
          Object[] prmT00019;
          prmT00019 = new Object[] {
          new ParDef("@ClienteId",GXType.Int16,4,0)
          };
          Object[] prmT00014;
          prmT00014 = new Object[] {
          new ParDef("@ClienteId",GXType.Int16,4,0)
          };
          Object[] prmT000110;
          prmT000110 = new Object[] {
          new ParDef("@ClienteId",GXType.Int16,4,0) ,
          new ParDef("@ClienteNome",GXType.NChar,100,0) ,
          new ParDef("@ClienteDocumento",GXType.NChar,20,0)
          };
          Object[] prmT000111;
          prmT000111 = new Object[] {
          new ParDef("@ClienteNome",GXType.NChar,100,0) ,
          new ParDef("@ClienteDocumento",GXType.NChar,20,0) ,
          new ParDef("@ClienteId",GXType.Int16,4,0)
          };
          Object[] prmT000112;
          prmT000112 = new Object[] {
          new ParDef("@ClienteId",GXType.Int16,4,0)
          };
          Object[] prmT000113;
          prmT000113 = new Object[] {
          };
          Object[] prmT000114;
          prmT000114 = new Object[] {
          new ParDef("@ClienteId",GXType.Int16,4,0) ,
          new ParDef("@ClienteEnderecoId",GXType.Int16,4,0)
          };
          Object[] prmT000115;
          prmT000115 = new Object[] {
          new ParDef("@ClienteId",GXType.Int16,4,0) ,
          new ParDef("@ClienteEnderecoId",GXType.Int16,4,0)
          };
          Object[] prmT00013;
          prmT00013 = new Object[] {
          new ParDef("@ClienteId",GXType.Int16,4,0) ,
          new ParDef("@ClienteEnderecoId",GXType.Int16,4,0)
          };
          Object[] prmT00012;
          prmT00012 = new Object[] {
          new ParDef("@ClienteId",GXType.Int16,4,0) ,
          new ParDef("@ClienteEnderecoId",GXType.Int16,4,0)
          };
          Object[] prmT000116;
          prmT000116 = new Object[] {
          new ParDef("@ClienteId",GXType.Int16,4,0) ,
          new ParDef("@ClienteEnderecoId",GXType.Int16,4,0) ,
          new ParDef("@ClienteEnderecoEnderecoLogrado",GXType.NChar,100,0)
          };
          Object[] prmT000117;
          prmT000117 = new Object[] {
          new ParDef("@ClienteEnderecoEnderecoLogrado",GXType.NChar,100,0) ,
          new ParDef("@ClienteId",GXType.Int16,4,0) ,
          new ParDef("@ClienteEnderecoId",GXType.Int16,4,0)
          };
          Object[] prmT000118;
          prmT000118 = new Object[] {
          new ParDef("@ClienteId",GXType.Int16,4,0) ,
          new ParDef("@ClienteEnderecoId",GXType.Int16,4,0)
          };
          Object[] prmT000119;
          prmT000119 = new Object[] {
          new ParDef("@ClienteId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00012", "SELECT [ClienteId], [ClienteEnderecoId], [ClienteEnderecoEnderecoLogrado] FROM [ClienteEndereco] WITH (UPDLOCK) WHERE [ClienteId] = @ClienteId AND [ClienteEnderecoId] = @ClienteEnderecoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00012,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00013", "SELECT [ClienteId], [ClienteEnderecoId], [ClienteEnderecoEnderecoLogrado] FROM [ClienteEndereco] WHERE [ClienteId] = @ClienteId AND [ClienteEnderecoId] = @ClienteEnderecoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00013,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00014", "SELECT [ClienteId], [ClienteNome], [ClienteDocumento] FROM [Cliente] WITH (UPDLOCK) WHERE [ClienteId] = @ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00014,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00015", "SELECT [ClienteId], [ClienteNome], [ClienteDocumento] FROM [Cliente] WHERE [ClienteId] = @ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00015,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00016", "SELECT TM1.[ClienteId], TM1.[ClienteNome], TM1.[ClienteDocumento] FROM [Cliente] TM1 WHERE TM1.[ClienteId] = @ClienteId ORDER BY TM1.[ClienteId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00016,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00017", "SELECT [ClienteId] FROM [Cliente] WHERE [ClienteId] = @ClienteId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00017,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00018", "SELECT TOP 1 [ClienteId] FROM [Cliente] WHERE ( [ClienteId] > @ClienteId) ORDER BY [ClienteId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00018,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00019", "SELECT TOP 1 [ClienteId] FROM [Cliente] WHERE ( [ClienteId] < @ClienteId) ORDER BY [ClienteId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00019,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000110", "INSERT INTO [Cliente]([ClienteId], [ClienteNome], [ClienteDocumento]) VALUES(@ClienteId, @ClienteNome, @ClienteDocumento)", GxErrorMask.GX_NOMASK,prmT000110)
             ,new CursorDef("T000111", "UPDATE [Cliente] SET [ClienteNome]=@ClienteNome, [ClienteDocumento]=@ClienteDocumento  WHERE [ClienteId] = @ClienteId", GxErrorMask.GX_NOMASK,prmT000111)
             ,new CursorDef("T000112", "DELETE FROM [Cliente]  WHERE [ClienteId] = @ClienteId", GxErrorMask.GX_NOMASK,prmT000112)
             ,new CursorDef("T000113", "SELECT [ClienteId] FROM [Cliente] ORDER BY [ClienteId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000113,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000114", "SELECT [ClienteId], [ClienteEnderecoId], [ClienteEnderecoEnderecoLogrado] FROM [ClienteEndereco] WHERE [ClienteId] = @ClienteId and [ClienteEnderecoId] = @ClienteEnderecoId ORDER BY [ClienteId], [ClienteEnderecoId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000114,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000115", "SELECT [ClienteId], [ClienteEnderecoId] FROM [ClienteEndereco] WHERE [ClienteId] = @ClienteId AND [ClienteEnderecoId] = @ClienteEnderecoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000115,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000116", "INSERT INTO [ClienteEndereco]([ClienteId], [ClienteEnderecoId], [ClienteEnderecoEnderecoLogrado]) VALUES(@ClienteId, @ClienteEnderecoId, @ClienteEnderecoEnderecoLogrado)", GxErrorMask.GX_NOMASK,prmT000116)
             ,new CursorDef("T000117", "UPDATE [ClienteEndereco] SET [ClienteEnderecoEnderecoLogrado]=@ClienteEnderecoEnderecoLogrado  WHERE [ClienteId] = @ClienteId AND [ClienteEnderecoId] = @ClienteEnderecoId", GxErrorMask.GX_NOMASK,prmT000117)
             ,new CursorDef("T000118", "DELETE FROM [ClienteEndereco]  WHERE [ClienteId] = @ClienteId AND [ClienteEnderecoId] = @ClienteEnderecoId", GxErrorMask.GX_NOMASK,prmT000118)
             ,new CursorDef("T000119", "SELECT [ClienteId], [ClienteEnderecoId] FROM [ClienteEndereco] WHERE [ClienteId] = @ClienteId ORDER BY [ClienteId], [ClienteEnderecoId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000119,11, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 17 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
       }
    }

 }

}
