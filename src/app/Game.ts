export interface Game {
  name?: string;
  description?: string;
  released?: string;
  website?: string;
  backgroundImage?: string;
  metacritic?: number;
  metacriticUrl?: string;
  genres?: Genre[];
  publishers?: Publisher[];
  parentPlatforms?: ParentPlatform[];
  ratings?: Rating[];
  screenShorts?: ScreenShort[];
  trailers?: Trailer[];
}

export interface Trailer {
  max: string;
}

export interface Rating {
  id: number;
  count: number;
  title: string;
}

export interface ScreenShort {
  image: string;
}

export interface ParentPlatform {
  name: string;
}

export interface Publisher {
  name: string;
}

export interface Genre {
  name: string;
}

export interface APIResponse<T>
{
  results:Array<T>;
}
