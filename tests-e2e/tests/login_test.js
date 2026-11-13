Feature('API Health Check via Browser');

Scenario('user can view root API page', ({ I }) => {
  I.amOnPage('/');
  // Verify something that actually renders, or remove codeceptjs if not needed
});