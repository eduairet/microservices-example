import { create } from 'zustand/react';

type State = {
  searchText: string | undefined;
  page: number | undefined;
  pageSize: number | undefined;
  pageCount: number | undefined;
  sortBy: string | undefined;
  sortDirection: 'Asc' | 'Desc' | undefined;
};

type Actions = {
  setParams: (newParams: Partial<State>) => void;
  reset: () => void;
};

const initialState: State = {
  searchText: undefined,
  page: undefined,
  pageSize: undefined,
  pageCount: undefined,
  sortBy: undefined,
  sortDirection: undefined,
};

export const useParamsStore = create<State & Actions>(set => ({
  ...initialState,
  setParams: (newParams: Partial<State>) =>
    set(state => {
      if (newParams.page) {
        return {
          ...state,
          page: newParams.page,
        };
      } else {
        return {
          ...state,
          ...newParams,
          page: 1,
        };
      }
    }),
  reset: () => set(() => ({ ...initialState })),
}));
