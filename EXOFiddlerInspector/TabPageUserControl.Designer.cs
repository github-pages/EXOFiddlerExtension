namespace EXOFiddlerInspector
{
    partial class TabPageUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabPageUserControl));
            this.UserAccountGroupBox = new System.Windows.Forms.GroupBox();
            this.Base64DecodeTextBox = new System.Windows.Forms.TextBox();
            this.ImmutableIDTextBox = new System.Windows.Forms.TextBox();
            this.MailboxGUIDsTextBox = new System.Windows.Forms.TextBox();
            this.RedirectAddressTextBox = new System.Windows.Forms.TextBox();
            this.AnchorMailboxTextBox = new System.Windows.Forms.TextBox();
            this.UserIdentityTextBox = new System.Windows.Forms.TextBox();
            this.Base64DecodeLabel = new System.Windows.Forms.Label();
            this.ImmutableIDLabel = new System.Windows.Forms.Label();
            this.MailboxGUIDsLabel = new System.Windows.Forms.Label();
            this.RedirectAddressLabel = new System.Windows.Forms.Label();
            this.AnchorMailboxLabel = new System.Windows.Forms.Label();
            this.UserIdentityLabel = new System.Windows.Forms.Label();
            this.IDPLabel = new System.Windows.Forms.Label();
            this.AuthenticationGroupBox = new System.Windows.Forms.GroupBox();
            this.SAMLRequestResponseTextBox = new System.Windows.Forms.TextBox();
            this.AuthenticationTypeUsedOnMAPITextBox = new System.Windows.Forms.TextBox();
            this.EXOAuthenticationCapabilityTextBox = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.AuthenticationTypeTextBox = new System.Windows.Forms.TextBox();
            this.IdentityProviderLinkLabel = new System.Windows.Forms.LinkLabel();
            this.OpenSAMLSigningCertificate = new System.Windows.Forms.Button();
            this.SAMLRequestResponseLabel = new System.Windows.Forms.Label();
            this.AuthenticationTypeUsedMAPILabel = new System.Windows.Forms.Label();
            this.EXOAuthenticationCapabilityLabel = new System.Windows.Forms.Label();
            this.OutlookAuthenticationCapabilityLabel = new System.Windows.Forms.Label();
            this.AuthenticationTypeLabel = new System.Windows.Forms.Label();
            this.AutodiscoverGroupBox = new System.Windows.Forms.GroupBox();
            this.EXOAutodiscoverResponseTextBox = new System.Windows.Forms.TextBox();
            this.OnPremiseAutodiscoverResponseTextBox = new System.Windows.Forms.TextBox();
            this.AutodiscoverPointsToTextBox = new System.Windows.Forms.TextBox();
            this.OnPremiseAutodiscoverResponseLabel = new System.Windows.Forms.Label();
            this.EXOAutodiscoverResponseLabel = new System.Windows.Forms.Label();
            this.AutodiscoverPointsToLabel = new System.Windows.Forms.Label();
            this.SessionSummaryGroupBox = new System.Windows.Forms.GroupBox();
            this.HTTP5xxTextBox = new System.Windows.Forms.TextBox();
            this.HTTP503FederatedSTSUnreachableTextBox = new System.Windows.Forms.TextBox();
            this.HTTP403AccessDeniedTextBox = new System.Windows.Forms.TextBox();
            this.HTTP200FailuresLurking = new System.Windows.Forms.TextBox();
            this.HTTP200AutodiscoverSOutlookComTextBox = new System.Windows.Forms.TextBox();
            this.HTTP5xxLabel = new System.Windows.Forms.Label();
            this.HTTP503FederatedSTSUnreachableLabel = new System.Windows.Forms.Label();
            this.HTTP403AccessDeniedLabel = new System.Windows.Forms.Label();
            this.HTTP200FailuresLurkingLabel = new System.Windows.Forms.Label();
            this.HTTP200FromEXOLabel = new System.Windows.Forms.Label();
            this.EXOSummaryLabel = new System.Windows.Forms.Label();
            this.UserAccountGroupBox.SuspendLayout();
            this.AuthenticationGroupBox.SuspendLayout();
            this.AutodiscoverGroupBox.SuspendLayout();
            this.SessionSummaryGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // UserAccountGroupBox
            // 
            this.UserAccountGroupBox.Controls.Add(this.Base64DecodeTextBox);
            this.UserAccountGroupBox.Controls.Add(this.ImmutableIDTextBox);
            this.UserAccountGroupBox.Controls.Add(this.MailboxGUIDsTextBox);
            this.UserAccountGroupBox.Controls.Add(this.RedirectAddressTextBox);
            this.UserAccountGroupBox.Controls.Add(this.AnchorMailboxTextBox);
            this.UserAccountGroupBox.Controls.Add(this.UserIdentityTextBox);
            this.UserAccountGroupBox.Controls.Add(this.Base64DecodeLabel);
            this.UserAccountGroupBox.Controls.Add(this.ImmutableIDLabel);
            this.UserAccountGroupBox.Controls.Add(this.MailboxGUIDsLabel);
            this.UserAccountGroupBox.Controls.Add(this.RedirectAddressLabel);
            this.UserAccountGroupBox.Controls.Add(this.AnchorMailboxLabel);
            this.UserAccountGroupBox.Controls.Add(this.UserIdentityLabel);
            this.UserAccountGroupBox.Location = new System.Drawing.Point(7, 72);
            this.UserAccountGroupBox.Name = "UserAccountGroupBox";
            this.UserAccountGroupBox.Size = new System.Drawing.Size(417, 151);
            this.UserAccountGroupBox.TabIndex = 0;
            this.UserAccountGroupBox.TabStop = false;
            this.UserAccountGroupBox.Text = "User Account Details";
            // 
            // Base64DecodeTextBox
            // 
            this.Base64DecodeTextBox.Location = new System.Drawing.Point(207, 119);
            this.Base64DecodeTextBox.Name = "Base64DecodeTextBox";
            this.Base64DecodeTextBox.Size = new System.Drawing.Size(197, 20);
            this.Base64DecodeTextBox.TabIndex = 11;
            // 
            // ImmutableIDTextBox
            // 
            this.ImmutableIDTextBox.Location = new System.Drawing.Point(207, 99);
            this.ImmutableIDTextBox.Name = "ImmutableIDTextBox";
            this.ImmutableIDTextBox.Size = new System.Drawing.Size(197, 20);
            this.ImmutableIDTextBox.TabIndex = 10;
            // 
            // MailboxGUIDsTextBox
            // 
            this.MailboxGUIDsTextBox.Location = new System.Drawing.Point(207, 79);
            this.MailboxGUIDsTextBox.Name = "MailboxGUIDsTextBox";
            this.MailboxGUIDsTextBox.Size = new System.Drawing.Size(197, 20);
            this.MailboxGUIDsTextBox.TabIndex = 9;
            // 
            // RedirectAddressTextBox
            // 
            this.RedirectAddressTextBox.Location = new System.Drawing.Point(207, 59);
            this.RedirectAddressTextBox.Name = "RedirectAddressTextBox";
            this.RedirectAddressTextBox.Size = new System.Drawing.Size(197, 20);
            this.RedirectAddressTextBox.TabIndex = 8;
            // 
            // AnchorMailboxTextBox
            // 
            this.AnchorMailboxTextBox.Location = new System.Drawing.Point(207, 39);
            this.AnchorMailboxTextBox.Name = "AnchorMailboxTextBox";
            this.AnchorMailboxTextBox.Size = new System.Drawing.Size(197, 20);
            this.AnchorMailboxTextBox.TabIndex = 7;
            // 
            // UserIdentityTextBox
            // 
            this.UserIdentityTextBox.Location = new System.Drawing.Point(207, 19);
            this.UserIdentityTextBox.Name = "UserIdentityTextBox";
            this.UserIdentityTextBox.Size = new System.Drawing.Size(197, 20);
            this.UserIdentityTextBox.TabIndex = 6;
            // 
            // Base64DecodeLabel
            // 
            this.Base64DecodeLabel.AutoSize = true;
            this.Base64DecodeLabel.Location = new System.Drawing.Point(7, 122);
            this.Base64DecodeLabel.Name = "Base64DecodeLabel";
            this.Base64DecodeLabel.Size = new System.Drawing.Size(84, 13);
            this.Base64DecodeLabel.TabIndex = 5;
            this.Base64DecodeLabel.Text = "Base64 Decode";
            // 
            // ImmutableIDLabel
            // 
            this.ImmutableIDLabel.AutoSize = true;
            this.ImmutableIDLabel.Location = new System.Drawing.Point(7, 102);
            this.ImmutableIDLabel.Name = "ImmutableIDLabel";
            this.ImmutableIDLabel.Size = new System.Drawing.Size(66, 13);
            this.ImmutableIDLabel.TabIndex = 4;
            this.ImmutableIDLabel.Text = "ImmutableID";
            // 
            // MailboxGUIDsLabel
            // 
            this.MailboxGUIDsLabel.AutoSize = true;
            this.MailboxGUIDsLabel.Location = new System.Drawing.Point(7, 82);
            this.MailboxGUIDsLabel.Name = "MailboxGUIDsLabel";
            this.MailboxGUIDsLabel.Size = new System.Drawing.Size(78, 13);
            this.MailboxGUIDsLabel.TabIndex = 3;
            this.MailboxGUIDsLabel.Text = "Mailbox GUIDs";
            // 
            // RedirectAddressLabel
            // 
            this.RedirectAddressLabel.AutoSize = true;
            this.RedirectAddressLabel.Location = new System.Drawing.Point(7, 62);
            this.RedirectAddressLabel.Name = "RedirectAddressLabel";
            this.RedirectAddressLabel.Size = new System.Drawing.Size(88, 13);
            this.RedirectAddressLabel.TabIndex = 2;
            this.RedirectAddressLabel.Text = "Redirect Address";
            // 
            // AnchorMailboxLabel
            // 
            this.AnchorMailboxLabel.AutoSize = true;
            this.AnchorMailboxLabel.Location = new System.Drawing.Point(7, 42);
            this.AnchorMailboxLabel.Name = "AnchorMailboxLabel";
            this.AnchorMailboxLabel.Size = new System.Drawing.Size(80, 13);
            this.AnchorMailboxLabel.TabIndex = 1;
            this.AnchorMailboxLabel.Text = "Anchor Mailbox";
            // 
            // UserIdentityLabel
            // 
            this.UserIdentityLabel.AutoSize = true;
            this.UserIdentityLabel.Location = new System.Drawing.Point(7, 22);
            this.UserIdentityLabel.Name = "UserIdentityLabel";
            this.UserIdentityLabel.Size = new System.Drawing.Size(66, 13);
            this.UserIdentityLabel.TabIndex = 0;
            this.UserIdentityLabel.Text = "User Identity";
            // 
            // IDPLabel
            // 
            this.IDPLabel.AutoSize = true;
            this.IDPLabel.Location = new System.Drawing.Point(7, 22);
            this.IDPLabel.Name = "IDPLabel";
            this.IDPLabel.Size = new System.Drawing.Size(83, 13);
            this.IDPLabel.TabIndex = 6;
            this.IDPLabel.Text = "Identity Provider";
            // 
            // AuthenticationGroupBox
            // 
            this.AuthenticationGroupBox.Controls.Add(this.SAMLRequestResponseTextBox);
            this.AuthenticationGroupBox.Controls.Add(this.AuthenticationTypeUsedOnMAPITextBox);
            this.AuthenticationGroupBox.Controls.Add(this.EXOAuthenticationCapabilityTextBox);
            this.AuthenticationGroupBox.Controls.Add(this.textBox1);
            this.AuthenticationGroupBox.Controls.Add(this.AuthenticationTypeTextBox);
            this.AuthenticationGroupBox.Controls.Add(this.IdentityProviderLinkLabel);
            this.AuthenticationGroupBox.Controls.Add(this.OpenSAMLSigningCertificate);
            this.AuthenticationGroupBox.Controls.Add(this.SAMLRequestResponseLabel);
            this.AuthenticationGroupBox.Controls.Add(this.AuthenticationTypeUsedMAPILabel);
            this.AuthenticationGroupBox.Controls.Add(this.EXOAuthenticationCapabilityLabel);
            this.AuthenticationGroupBox.Controls.Add(this.OutlookAuthenticationCapabilityLabel);
            this.AuthenticationGroupBox.Controls.Add(this.AuthenticationTypeLabel);
            this.AuthenticationGroupBox.Controls.Add(this.IDPLabel);
            this.AuthenticationGroupBox.Location = new System.Drawing.Point(7, 229);
            this.AuthenticationGroupBox.Name = "AuthenticationGroupBox";
            this.AuthenticationGroupBox.Size = new System.Drawing.Size(417, 182);
            this.AuthenticationGroupBox.TabIndex = 1;
            this.AuthenticationGroupBox.TabStop = false;
            this.AuthenticationGroupBox.Text = "Authentication";
            // 
            // SAMLRequestResponseTextBox
            // 
            this.SAMLRequestResponseTextBox.Location = new System.Drawing.Point(207, 122);
            this.SAMLRequestResponseTextBox.Name = "SAMLRequestResponseTextBox";
            this.SAMLRequestResponseTextBox.Size = new System.Drawing.Size(197, 20);
            this.SAMLRequestResponseTextBox.TabIndex = 18;
            // 
            // AuthenticationTypeUsedOnMAPITextBox
            // 
            this.AuthenticationTypeUsedOnMAPITextBox.Location = new System.Drawing.Point(207, 102);
            this.AuthenticationTypeUsedOnMAPITextBox.Name = "AuthenticationTypeUsedOnMAPITextBox";
            this.AuthenticationTypeUsedOnMAPITextBox.Size = new System.Drawing.Size(197, 20);
            this.AuthenticationTypeUsedOnMAPITextBox.TabIndex = 17;
            // 
            // EXOAuthenticationCapabilityTextBox
            // 
            this.EXOAuthenticationCapabilityTextBox.Location = new System.Drawing.Point(207, 82);
            this.EXOAuthenticationCapabilityTextBox.Name = "EXOAuthenticationCapabilityTextBox";
            this.EXOAuthenticationCapabilityTextBox.Size = new System.Drawing.Size(197, 20);
            this.EXOAuthenticationCapabilityTextBox.TabIndex = 16;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(207, 62);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(197, 20);
            this.textBox1.TabIndex = 15;
            // 
            // AuthenticationTypeTextBox
            // 
            this.AuthenticationTypeTextBox.Location = new System.Drawing.Point(207, 42);
            this.AuthenticationTypeTextBox.Name = "AuthenticationTypeTextBox";
            this.AuthenticationTypeTextBox.Size = new System.Drawing.Size(197, 20);
            this.AuthenticationTypeTextBox.TabIndex = 14;
            // 
            // IdentityProviderLinkLabel
            // 
            this.IdentityProviderLinkLabel.AutoSize = true;
            this.IdentityProviderLinkLabel.Location = new System.Drawing.Point(204, 22);
            this.IdentityProviderLinkLabel.Name = "IdentityProviderLinkLabel";
            this.IdentityProviderLinkLabel.Size = new System.Drawing.Size(157, 13);
            this.IdentityProviderLinkLabel.TabIndex = 13;
            this.IdentityProviderLinkLabel.TabStop = true;
            this.IdentityProviderLinkLabel.Text = "https://sts.contoso.com/adfs/ls";
            // 
            // OpenSAMLSigningCertificate
            // 
            this.OpenSAMLSigningCertificate.Location = new System.Drawing.Point(238, 148);
            this.OpenSAMLSigningCertificate.Name = "OpenSAMLSigningCertificate";
            this.OpenSAMLSigningCertificate.Size = new System.Drawing.Size(166, 23);
            this.OpenSAMLSigningCertificate.TabIndex = 12;
            this.OpenSAMLSigningCertificate.Text = "Open SAML Signing Certificate";
            this.OpenSAMLSigningCertificate.UseVisualStyleBackColor = true;
            // 
            // SAMLRequestResponseLabel
            // 
            this.SAMLRequestResponseLabel.AutoSize = true;
            this.SAMLRequestResponseLabel.Location = new System.Drawing.Point(7, 125);
            this.SAMLRequestResponseLabel.Name = "SAMLRequestResponseLabel";
            this.SAMLRequestResponseLabel.Size = new System.Drawing.Size(132, 13);
            this.SAMLRequestResponseLabel.TabIndex = 11;
            this.SAMLRequestResponseLabel.Text = "SAML Request/Response";
            // 
            // AuthenticationTypeUsedMAPILabel
            // 
            this.AuthenticationTypeUsedMAPILabel.AutoSize = true;
            this.AuthenticationTypeUsedMAPILabel.Location = new System.Drawing.Point(7, 105);
            this.AuthenticationTypeUsedMAPILabel.Name = "AuthenticationTypeUsedMAPILabel";
            this.AuthenticationTypeUsedMAPILabel.Size = new System.Drawing.Size(174, 13);
            this.AuthenticationTypeUsedMAPILabel.TabIndex = 10;
            this.AuthenticationTypeUsedMAPILabel.Text = "Authentication Type Used on MAPI";
            // 
            // EXOAuthenticationCapabilityLabel
            // 
            this.EXOAuthenticationCapabilityLabel.AutoSize = true;
            this.EXOAuthenticationCapabilityLabel.Location = new System.Drawing.Point(7, 85);
            this.EXOAuthenticationCapabilityLabel.Name = "EXOAuthenticationCapabilityLabel";
            this.EXOAuthenticationCapabilityLabel.Size = new System.Drawing.Size(148, 13);
            this.EXOAuthenticationCapabilityLabel.TabIndex = 9;
            this.EXOAuthenticationCapabilityLabel.Text = "EXO Authentication Capability";
            // 
            // OutlookAuthenticationCapabilityLabel
            // 
            this.OutlookAuthenticationCapabilityLabel.AutoSize = true;
            this.OutlookAuthenticationCapabilityLabel.Location = new System.Drawing.Point(7, 65);
            this.OutlookAuthenticationCapabilityLabel.Name = "OutlookAuthenticationCapabilityLabel";
            this.OutlookAuthenticationCapabilityLabel.Size = new System.Drawing.Size(163, 13);
            this.OutlookAuthenticationCapabilityLabel.TabIndex = 8;
            this.OutlookAuthenticationCapabilityLabel.Text = "Outlook Authentication Capability";
            // 
            // AuthenticationTypeLabel
            // 
            this.AuthenticationTypeLabel.AutoSize = true;
            this.AuthenticationTypeLabel.Location = new System.Drawing.Point(7, 45);
            this.AuthenticationTypeLabel.Name = "AuthenticationTypeLabel";
            this.AuthenticationTypeLabel.Size = new System.Drawing.Size(102, 13);
            this.AuthenticationTypeLabel.TabIndex = 7;
            this.AuthenticationTypeLabel.Text = "Authentication Type";
            // 
            // AutodiscoverGroupBox
            // 
            this.AutodiscoverGroupBox.Controls.Add(this.EXOAutodiscoverResponseTextBox);
            this.AutodiscoverGroupBox.Controls.Add(this.OnPremiseAutodiscoverResponseTextBox);
            this.AutodiscoverGroupBox.Controls.Add(this.AutodiscoverPointsToTextBox);
            this.AutodiscoverGroupBox.Controls.Add(this.OnPremiseAutodiscoverResponseLabel);
            this.AutodiscoverGroupBox.Controls.Add(this.EXOAutodiscoverResponseLabel);
            this.AutodiscoverGroupBox.Controls.Add(this.AutodiscoverPointsToLabel);
            this.AutodiscoverGroupBox.Location = new System.Drawing.Point(7, 417);
            this.AutodiscoverGroupBox.Name = "AutodiscoverGroupBox";
            this.AutodiscoverGroupBox.Size = new System.Drawing.Size(417, 91);
            this.AutodiscoverGroupBox.TabIndex = 2;
            this.AutodiscoverGroupBox.TabStop = false;
            this.AutodiscoverGroupBox.Text = "Autodiscover";
            // 
            // EXOAutodiscoverResponseTextBox
            // 
            this.EXOAutodiscoverResponseTextBox.Location = new System.Drawing.Point(207, 59);
            this.EXOAutodiscoverResponseTextBox.Name = "EXOAutodiscoverResponseTextBox";
            this.EXOAutodiscoverResponseTextBox.Size = new System.Drawing.Size(197, 20);
            this.EXOAutodiscoverResponseTextBox.TabIndex = 5;
            // 
            // OnPremiseAutodiscoverResponseTextBox
            // 
            this.OnPremiseAutodiscoverResponseTextBox.Location = new System.Drawing.Point(207, 39);
            this.OnPremiseAutodiscoverResponseTextBox.Name = "OnPremiseAutodiscoverResponseTextBox";
            this.OnPremiseAutodiscoverResponseTextBox.Size = new System.Drawing.Size(197, 20);
            this.OnPremiseAutodiscoverResponseTextBox.TabIndex = 4;
            // 
            // AutodiscoverPointsToTextBox
            // 
            this.AutodiscoverPointsToTextBox.Location = new System.Drawing.Point(207, 19);
            this.AutodiscoverPointsToTextBox.Name = "AutodiscoverPointsToTextBox";
            this.AutodiscoverPointsToTextBox.Size = new System.Drawing.Size(197, 20);
            this.AutodiscoverPointsToTextBox.TabIndex = 3;
            // 
            // OnPremiseAutodiscoverResponseLabel
            // 
            this.OnPremiseAutodiscoverResponseLabel.AutoSize = true;
            this.OnPremiseAutodiscoverResponseLabel.Location = new System.Drawing.Point(7, 42);
            this.OnPremiseAutodiscoverResponseLabel.Name = "OnPremiseAutodiscoverResponseLabel";
            this.OnPremiseAutodiscoverResponseLabel.Size = new System.Drawing.Size(174, 13);
            this.OnPremiseAutodiscoverResponseLabel.TabIndex = 2;
            this.OnPremiseAutodiscoverResponseLabel.Text = "OnPremise Autodiscover Response";
            // 
            // EXOAutodiscoverResponseLabel
            // 
            this.EXOAutodiscoverResponseLabel.AutoSize = true;
            this.EXOAutodiscoverResponseLabel.Location = new System.Drawing.Point(7, 62);
            this.EXOAutodiscoverResponseLabel.Name = "EXOAutodiscoverResponseLabel";
            this.EXOAutodiscoverResponseLabel.Size = new System.Drawing.Size(139, 13);
            this.EXOAutodiscoverResponseLabel.TabIndex = 1;
            this.EXOAutodiscoverResponseLabel.Text = "EXOAutodiscoverResponse";
            // 
            // AutodiscoverPointsToLabel
            // 
            this.AutodiscoverPointsToLabel.AutoSize = true;
            this.AutodiscoverPointsToLabel.Location = new System.Drawing.Point(7, 22);
            this.AutodiscoverPointsToLabel.Name = "AutodiscoverPointsToLabel";
            this.AutodiscoverPointsToLabel.Size = new System.Drawing.Size(117, 13);
            this.AutodiscoverPointsToLabel.TabIndex = 0;
            this.AutodiscoverPointsToLabel.Text = "Autodiscover Points To";
            // 
            // SessionSummaryGroupBox
            // 
            this.SessionSummaryGroupBox.Controls.Add(this.HTTP5xxTextBox);
            this.SessionSummaryGroupBox.Controls.Add(this.HTTP503FederatedSTSUnreachableTextBox);
            this.SessionSummaryGroupBox.Controls.Add(this.HTTP403AccessDeniedTextBox);
            this.SessionSummaryGroupBox.Controls.Add(this.HTTP200FailuresLurking);
            this.SessionSummaryGroupBox.Controls.Add(this.HTTP200AutodiscoverSOutlookComTextBox);
            this.SessionSummaryGroupBox.Controls.Add(this.HTTP5xxLabel);
            this.SessionSummaryGroupBox.Controls.Add(this.HTTP503FederatedSTSUnreachableLabel);
            this.SessionSummaryGroupBox.Controls.Add(this.HTTP403AccessDeniedLabel);
            this.SessionSummaryGroupBox.Controls.Add(this.HTTP200FailuresLurkingLabel);
            this.SessionSummaryGroupBox.Controls.Add(this.HTTP200FromEXOLabel);
            this.SessionSummaryGroupBox.Location = new System.Drawing.Point(7, 514);
            this.SessionSummaryGroupBox.Name = "SessionSummaryGroupBox";
            this.SessionSummaryGroupBox.Size = new System.Drawing.Size(417, 130);
            this.SessionSummaryGroupBox.TabIndex = 3;
            this.SessionSummaryGroupBox.TabStop = false;
            this.SessionSummaryGroupBox.Text = "Session Summary";
            // 
            // HTTP5xxTextBox
            // 
            this.HTTP5xxTextBox.Location = new System.Drawing.Point(207, 99);
            this.HTTP5xxTextBox.Name = "HTTP5xxTextBox";
            this.HTTP5xxTextBox.Size = new System.Drawing.Size(197, 20);
            this.HTTP5xxTextBox.TabIndex = 9;
            // 
            // HTTP503FederatedSTSUnreachableTextBox
            // 
            this.HTTP503FederatedSTSUnreachableTextBox.Location = new System.Drawing.Point(207, 79);
            this.HTTP503FederatedSTSUnreachableTextBox.Name = "HTTP503FederatedSTSUnreachableTextBox";
            this.HTTP503FederatedSTSUnreachableTextBox.Size = new System.Drawing.Size(197, 20);
            this.HTTP503FederatedSTSUnreachableTextBox.TabIndex = 8;
            // 
            // HTTP403AccessDeniedTextBox
            // 
            this.HTTP403AccessDeniedTextBox.Location = new System.Drawing.Point(207, 59);
            this.HTTP403AccessDeniedTextBox.Name = "HTTP403AccessDeniedTextBox";
            this.HTTP403AccessDeniedTextBox.Size = new System.Drawing.Size(197, 20);
            this.HTTP403AccessDeniedTextBox.TabIndex = 7;
            // 
            // HTTP200FailuresLurking
            // 
            this.HTTP200FailuresLurking.Location = new System.Drawing.Point(207, 39);
            this.HTTP200FailuresLurking.Name = "HTTP200FailuresLurking";
            this.HTTP200FailuresLurking.Size = new System.Drawing.Size(197, 20);
            this.HTTP200FailuresLurking.TabIndex = 6;
            // 
            // HTTP200AutodiscoverSOutlookComTextBox
            // 
            this.HTTP200AutodiscoverSOutlookComTextBox.Location = new System.Drawing.Point(207, 19);
            this.HTTP200AutodiscoverSOutlookComTextBox.Name = "HTTP200AutodiscoverSOutlookComTextBox";
            this.HTTP200AutodiscoverSOutlookComTextBox.Size = new System.Drawing.Size(197, 20);
            this.HTTP200AutodiscoverSOutlookComTextBox.TabIndex = 5;
            // 
            // HTTP5xxLabel
            // 
            this.HTTP5xxLabel.AutoSize = true;
            this.HTTP5xxLabel.Location = new System.Drawing.Point(7, 102);
            this.HTTP5xxLabel.Name = "HTTP5xxLabel";
            this.HTTP5xxLabel.Size = new System.Drawing.Size(55, 13);
            this.HTTP5xxLabel.TabIndex = 4;
            this.HTTP5xxLabel.Text = "HTTP 5xx";
            // 
            // HTTP503FederatedSTSUnreachableLabel
            // 
            this.HTTP503FederatedSTSUnreachableLabel.AutoSize = true;
            this.HTTP503FederatedSTSUnreachableLabel.Location = new System.Drawing.Point(7, 82);
            this.HTTP503FederatedSTSUnreachableLabel.Name = "HTTP503FederatedSTSUnreachableLabel";
            this.HTTP503FederatedSTSUnreachableLabel.Size = new System.Drawing.Size(200, 13);
            this.HTTP503FederatedSTSUnreachableLabel.TabIndex = 3;
            this.HTTP503FederatedSTSUnreachableLabel.Text = "HTTP 503 \"FederatedSTSUnreachable\"";
            // 
            // HTTP403AccessDeniedLabel
            // 
            this.HTTP403AccessDeniedLabel.AutoSize = true;
            this.HTTP403AccessDeniedLabel.Location = new System.Drawing.Point(7, 62);
            this.HTTP403AccessDeniedLabel.Name = "HTTP403AccessDeniedLabel";
            this.HTTP403AccessDeniedLabel.Size = new System.Drawing.Size(142, 13);
            this.HTTP403AccessDeniedLabel.TabIndex = 2;
            this.HTTP403AccessDeniedLabel.Text = "HTTP 403 \"Access Denied\"";
            // 
            // HTTP200FailuresLurkingLabel
            // 
            this.HTTP200FailuresLurkingLabel.AutoSize = true;
            this.HTTP200FailuresLurkingLabel.Location = new System.Drawing.Point(7, 42);
            this.HTTP200FailuresLurkingLabel.Name = "HTTP200FailuresLurkingLabel";
            this.HTTP200FailuresLurkingLabel.Size = new System.Drawing.Size(130, 13);
            this.HTTP200FailuresLurkingLabel.TabIndex = 1;
            this.HTTP200FailuresLurkingLabel.Text = "HTTP 200 Failures lurking";
            // 
            // HTTP200FromEXOLabel
            // 
            this.HTTP200FromEXOLabel.AutoSize = true;
            this.HTTP200FromEXOLabel.Location = new System.Drawing.Point(7, 22);
            this.HTTP200FromEXOLabel.Name = "HTTP200FromEXOLabel";
            this.HTTP200FromEXOLabel.Size = new System.Drawing.Size(190, 13);
            this.HTTP200FromEXOLabel.TabIndex = 0;
            this.HTTP200FromEXOLabel.Text = "HTTP 200 autodiscover-s.outlook.com";
            // 
            // EXOSummaryLabel
            // 
            this.EXOSummaryLabel.AutoSize = true;
            this.EXOSummaryLabel.Location = new System.Drawing.Point(4, 4);
            this.EXOSummaryLabel.Name = "EXOSummaryLabel";
            this.EXOSummaryLabel.Size = new System.Drawing.Size(391, 65);
            this.EXOSummaryLabel.TabIndex = 4;
            this.EXOSummaryLabel.Text = resources.GetString("EXOSummaryLabel.Text");
            // 
            // TabPageUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.EXOSummaryLabel);
            this.Controls.Add(this.SessionSummaryGroupBox);
            this.Controls.Add(this.AutodiscoverGroupBox);
            this.Controls.Add(this.AuthenticationGroupBox);
            this.Controls.Add(this.UserAccountGroupBox);
            this.Name = "TabPageUserControl";
            this.Size = new System.Drawing.Size(441, 657);
            this.UserAccountGroupBox.ResumeLayout(false);
            this.UserAccountGroupBox.PerformLayout();
            this.AuthenticationGroupBox.ResumeLayout(false);
            this.AuthenticationGroupBox.PerformLayout();
            this.AutodiscoverGroupBox.ResumeLayout(false);
            this.AutodiscoverGroupBox.PerformLayout();
            this.SessionSummaryGroupBox.ResumeLayout(false);
            this.SessionSummaryGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox UserAccountGroupBox;
        private System.Windows.Forms.Label Base64DecodeLabel;
        private System.Windows.Forms.Label ImmutableIDLabel;
        private System.Windows.Forms.Label MailboxGUIDsLabel;
        private System.Windows.Forms.Label RedirectAddressLabel;
        private System.Windows.Forms.Label AnchorMailboxLabel;
        private System.Windows.Forms.Label UserIdentityLabel;
        private System.Windows.Forms.Label IDPLabel;
        private System.Windows.Forms.GroupBox AuthenticationGroupBox;
        private System.Windows.Forms.Label AuthenticationTypeLabel;
        private System.Windows.Forms.GroupBox AutodiscoverGroupBox;
        private System.Windows.Forms.Label OnPremiseAutodiscoverResponseLabel;
        private System.Windows.Forms.Label EXOAutodiscoverResponseLabel;
        private System.Windows.Forms.Label AutodiscoverPointsToLabel;
        private System.Windows.Forms.Button OpenSAMLSigningCertificate;
        private System.Windows.Forms.Label SAMLRequestResponseLabel;
        private System.Windows.Forms.Label AuthenticationTypeUsedMAPILabel;
        private System.Windows.Forms.Label EXOAuthenticationCapabilityLabel;
        private System.Windows.Forms.Label OutlookAuthenticationCapabilityLabel;
        private System.Windows.Forms.GroupBox SessionSummaryGroupBox;
        private System.Windows.Forms.Label HTTP5xxLabel;
        private System.Windows.Forms.Label HTTP503FederatedSTSUnreachableLabel;
        private System.Windows.Forms.Label HTTP403AccessDeniedLabel;
        private System.Windows.Forms.Label HTTP200FailuresLurkingLabel;
        private System.Windows.Forms.Label HTTP200FromEXOLabel;
        private System.Windows.Forms.TextBox Base64DecodeTextBox;
        private System.Windows.Forms.TextBox ImmutableIDTextBox;
        private System.Windows.Forms.TextBox MailboxGUIDsTextBox;
        private System.Windows.Forms.TextBox RedirectAddressTextBox;
        private System.Windows.Forms.TextBox AnchorMailboxTextBox;
        private System.Windows.Forms.TextBox UserIdentityTextBox;
        private System.Windows.Forms.TextBox SAMLRequestResponseTextBox;
        private System.Windows.Forms.TextBox AuthenticationTypeUsedOnMAPITextBox;
        private System.Windows.Forms.TextBox EXOAuthenticationCapabilityTextBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox AuthenticationTypeTextBox;
        private System.Windows.Forms.LinkLabel IdentityProviderLinkLabel;
        private System.Windows.Forms.TextBox EXOAutodiscoverResponseTextBox;
        private System.Windows.Forms.TextBox OnPremiseAutodiscoverResponseTextBox;
        private System.Windows.Forms.TextBox AutodiscoverPointsToTextBox;
        private System.Windows.Forms.TextBox HTTP5xxTextBox;
        private System.Windows.Forms.TextBox HTTP503FederatedSTSUnreachableTextBox;
        private System.Windows.Forms.TextBox HTTP403AccessDeniedTextBox;
        private System.Windows.Forms.TextBox HTTP200FailuresLurking;
        private System.Windows.Forms.TextBox HTTP200AutodiscoverSOutlookComTextBox;
        private System.Windows.Forms.Label EXOSummaryLabel;
    }
}
