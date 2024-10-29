const isQueryStart = (url: string) => (url.includes('?') ? '&' : '?');

export const buildGetRequestUrl = (
  startUrl: string,
  searchId: string,
  searchName: string,
  searchCategory: string,
  sortType: string,
  sortOrder: string,
): string => {
  let url: string = startUrl;
  if (searchId != '' && !url.includes('Id')) {
    url += isQueryStart(url);
    url += `Id=${searchId}`;
    return url;
  }
  if (searchName != '' && !url.includes('SearchName')) {
    url += isQueryStart(url);
    url += `SearchName=${searchName}`;
  }
  if (searchCategory != '' && !url.includes('SearchCategory')) {
    url += isQueryStart(url);
    url += `SearchCategory=${searchCategory}`;
  }
  if (sortType != '' && !url.includes('SortType')) {
    url += isQueryStart(url);
    url += `SortType=${sortType}`;
  }
  if (sortOrder != '' && !url.includes('SortOrder')) {
    url += isQueryStart(url);
    url += `SortOrder=${sortOrder}`;
  }
  return url;
};
