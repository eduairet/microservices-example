export const fetchData = async <T>(url: string, options?: RequestInit): Promise<T> => {
  const response = await fetch(url, options);

  if (!response.ok) throw new Error(response.statusText || `Error fetching ${url}`);

  return response.json();
};
