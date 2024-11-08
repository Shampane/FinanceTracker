const isQueryStart = (url: string) => (url.includes("?") ? "&" : "?");

const addToUrl = (prop: string | number, propName: string, url: string) => {
  let newUrl = url;
  if (prop != "" && !url.includes(propName)) {
    newUrl += isQueryStart(url);
    newUrl += `${propName}=${prop}`;
  }
  return newUrl;
};

export const buildGetRequestUrl = (
  startUrl: string,
  searchId: string,
  searchName: string,
  searchCategory: string,
  sortType: string,
  sortOrder: string,
  paginationSize: number,
  paginationPage: number
): string => {
  let url: string = startUrl;

  url = addToUrl(searchId, "SearchId", url);
  url = addToUrl(sortType, "SortType", url);
  url = addToUrl(sortOrder, "SortOrder", url);
  url = addToUrl(paginationSize, "LimitSize", url);
  url = addToUrl(paginationPage, "LimitPage", url);
  url = addToUrl(searchName, "SearchName", url);
  url = addToUrl(searchCategory, "SearchCategory", url);

  return url;
};
