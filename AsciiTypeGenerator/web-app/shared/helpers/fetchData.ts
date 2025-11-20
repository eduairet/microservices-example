export const fetchData = async <T>(url: string, options?: RequestInit): Promise<Response> => {
  const response = await fetch(url, options);

  if (!response.ok) throw new Error(response.statusText || `Error fetching ${url}`);

  return response;
};
