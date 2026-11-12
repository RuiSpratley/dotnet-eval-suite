Feature('Sample App UI Evaluation');

Scenario('Check API Swagger page loads in browser', ({ I }) => {
  // Update port to match your running .NET API
  I.amOnPage('http://localhost:5148/swagger'); 
  I.see('WeatherForecast');
});