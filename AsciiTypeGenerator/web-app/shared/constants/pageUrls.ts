export const pageUrls = {
  HOME: '/',
  HOME_: (searchText: string) => {
    const query = searchText ? `?SearchText=${encodeURIComponent(searchText)}` : '';
    return `/${query}`;
  },
};
