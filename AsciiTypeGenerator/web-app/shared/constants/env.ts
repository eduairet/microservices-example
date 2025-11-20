export const GATEWAY_SERVICE_URL =
  process.env.NEXT_PUBLIC_GATEWAY_SERVICE_URL ||
  (() => {
    throw new Error('GATEWAY_SERVICE_URL is not defined');
  })();

export const AUTH_SERVICE_URL =
  process.env.NEXT_PUBLIC_AUTH_SERVICE_URL ||
  (() => {
    throw new Error('AUTH_SERVICE_URL is not defined');
  })();
