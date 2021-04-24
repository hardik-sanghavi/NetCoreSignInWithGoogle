# .Net Core Sign In With Google without the use of Identity
This repository add the Sign in with google functionality for .net core without using of identity module.

**How to get the google Id?**
1. Go to the Credentials page https://console.developers.google.com/apis/credentials.
2. Click Create credentials > OAuth client ID.
3. Select the Web application application type.
4. Name your OAuth 2.0 client and click Create.

**How to implement?**
1. Add the div and related google js in your page.
  Div: 
  ```
  <div style="display:flex;justify-content:center;">
    <div id="g_id_onload"
         data-client_id="88815sdsd.apps.googleusercontent.com" @*enter your google clientId*@
         data-login_uri="https:localhost:44369/sso/google" @*enter your domain end point*@
         data-auto_prompt="false"
         data-context="signin">
    </div>
    <div class="g_id_signin"
         data-type="standard"
         data-size="large"
         data-theme="outline"
         data-text="continue_with"
         data-shape="rectangular"
         data-logo_alignment="left">
    </div>
</div>

  Script: <script src="https://accounts.google.com/gsi/client" async defer></script>
```
2. Authenticate on backend and add your site login logic.
  Need to authenticate the token by the google api https://oauth2.googleapis.com/tokeninfo. This logic implemented in the GoogleSSO action method of Account Controller.
  
