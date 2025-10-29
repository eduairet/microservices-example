'use client';

import { useRouter } from 'next/navigation';
import { type FC } from 'react';
import Pagination from '@/components/layout/Pagination';
import { useParamsStore } from '@/hooks/useParamsStore';
import { pageUrls } from '@/shared/constants';

const HomePagination: FC = () => {
  const params = useParamsStore.getState();
  const router = useRouter();

  const navigateToPage = (page: number) => {
    router.push(
      pageUrls.HOME_(params.searchText, page, params.pageSize, params.sortBy, params.sortDirection)
    );
  };

  return (
    <div className="mt-8 flex justify-start w-full">
      <Pagination
        onPageChange={navigateToPage}
        currentPage={params.page ?? 1}
        totalPages={params.pageCount ?? 1}
      />
    </div>
  );
};

export default HomePagination;
