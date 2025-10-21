export const GATEWAY_SERVICE_URL =
  process.env.NEXT_PUBLIC_GATEWAY_SERVICE_URL ||
  (() => {
    throw new Error('GATEWAY_SERVICE_URL is not defined');
  })();
