const { spec } = require('pactum');

const API_URL = process.env.API_URL || 'http://localhost:5000';

describe('Sample .NET API Contract Tests via Pactum', () => {
  it('should get weather forecasts from .NET backend successfully', async () => {
    await spec()
      .get(`${API_URL}/weatherforecast`)
      .expectStatus(200);
  });
});