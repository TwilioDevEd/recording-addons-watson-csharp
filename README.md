<a href="https://www.twilio.com">
  <img src="https://static0.twilio.com/marketing/bundles/marketing/img/logos/wordmark-red.svg" alt="Twilio" width="250" />
</a>

# Recording Add-Ons for C# (ASP.NET MVC)

This application should give you a ready-made starting point for writing your own voice transcription app with Twilio and IBM Watson.

[Read the full tutorial here]()!

### Local development

1. To run this application with Twilio, you will need to make it publicly accessible. [We recommend using ngrok for this.](https://www.twilio.com/docs/usage/tutorials/how-use-ngrok-windows-and-visual-studio-test-webhooks) Install [ngrok](https://ngrok.com/download) now, or install the [ngrok Extensions for Visual Studio](https://marketplace.visualstudio.com/items?itemName=DavidProthero.NgrokExtensions).

2. First clone this repository and `cd` into its directory:
   ```
   git clone git@github.com:TwilioDevEd/recording-addons-watson-csharp.git

   cd recording-addons-watson-csharp
   ```

3. After downloading the repo, open the `recording-addons-watson-csharp/Web.config.example` file and edit the `TwilioAccountSid` and `TwilioAutToken` with your own data:
```xml
<appSettings>
	<add key="TwilioAccountSid" value="ACxxx" />
	<add key="TwilioAuthToken" value="xxx" />
</appSettings>
```

4. Update those values in the config file to match your Twilio account. You can get your Account SID and auth token from your [dashboard](https://www.twilio.com/console). You can buy a Twilio phone number [right here](https://www.twilio.com/user/account/phone-numbers/search) (the one you are going to call to test the application).

5. Build the solution in Visual Studio.

6. Run the application. You'll see it start up at `http://localhost:46230`, but we aren't quite ready yet.

7. Start ngrok now, to make the application publicly accessible. Either run this command:
    ```
    ngrok http 1229 -host-header="localhost:46230"
    ```

    Or, if you installed the [ngrok Extensions for Visual Studio](https://marketplace.visualstudio.com/items?itemName=DavidProthero.NgrokExtensions), choose "Start ngrok Tunnel" from the "Tools" menu in Visual Studio.

8. Open [the number management page](https://www.twilio.com/user/account/phone-numbers/incoming) and open a number's configuration by clicking on it.

    For this application, you must set the voice webhook of your number to something like this:

    ```
    http://<your-ngrok-subdomain>.ngrok.io/voice
    ```

    And in this case set the `POST` method on the configuration for this webhook.

9. Latly, you need to setup the IBM Watson Speech to Text Add-On [here](https://www.twilio.com/console/add-ons/XB85b56ed9ce713e0ac62342b901233193). 

    After installing it, mark the box `Record Verb Recordings`

    On the field `CALLBACK URL`, add something like this:

    ```
    http://<your-ngrok-subdomain>.ngrok.io/callback
    ```

10. Now, just call your number! You should listen to your own recording and see the transcript text on the HTTP Response.

## Meta

* No warranty expressed or implied. Software is as is. Diggity.
* [MIT License](http://www.opensource.org/licenses/mit-license.html)
* Lovingly crafted by Twilio Developer Education.
