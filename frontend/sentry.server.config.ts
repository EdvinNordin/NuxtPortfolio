import * as Sentry from "@sentry/nuxt";
 
Sentry.init({
  dsn: "https://529393ab0d28385133872d77ac60bd33@o4510051184541696.ingest.de.sentry.io/4510051191160912",

  // We recommend adjusting this value in production, or using tracesSampler
  // for finer control
  tracesSampleRate: 1.0,

  // Enable logs to be sent to Sentry
  enableLogs: true,
  
  // Setting this option to true will print useful information to the console while you're setting up Sentry.
  debug: false,
});
