const { spec } = require('pactum');

describe('Sample .NET API Contract Tests via Pactum', () => {
  // Ensure this port matches the one your .NET API prints when you run it (e.g., 5000 or 5258)
  const baseUrl = 'http://localhost:5000'; 

  it('should get weather forecasts from .NET backend', async () => {
    await spec()
      .get(`${baseUrl}/weatherforecast`)
      .expectStatus(200);
  });
});