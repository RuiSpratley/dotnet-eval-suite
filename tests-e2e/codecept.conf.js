/** @type {CodeceptJS.MainConfig} */
export const config = {
  tests: './tests/*_test.js',
  output: './output',
  helpers: {
   Playwright: {
      url: 'http://localhost:5000',
      show: false, // <-- Set to false to force headless mode in CI
      browser: 'chromium',
      restart: false,
      keepCookies: false
    }
  },
  include: {
    I: './steps_file.js'
  },
  noGlobals: true,
  plugins: {},
  name: 'tests-e2e'
}