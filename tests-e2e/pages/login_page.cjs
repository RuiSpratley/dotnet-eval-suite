const { I } = inject();

module.exports = {
  fields: {
    // Update these selectors to match your actual HTML elements (e.g., input[name='Email'] or #Email)
    username: 'input[name="Username"]', 
    password: 'input[name="Password"]',
  },
    submitButton: 'button[type="submit"]',

  login(username, password) {
    I.fillField(this.fields.username, username);
    I.fillField(this.fields.password, password);
    I.click(this.submitButton);
  }
};