'use client';

import { FC } from 'react';
import IconChevron, { ChevronDirection } from '@/components/icons/IconChevron';

interface IProps {
  currentPage: number;
  totalPages: number;
  onPageChange: (page: number) => void;
}

const buttonClassName =
  'flex items-center justify-center font-medium text-accent disabled:cursor-auto disabled:text-accent/50 transition-colors hover:text-foreground cursor-pointer';

const ellipsisClassName = 'text-accent';

const Pagination: FC<IProps> = ({ currentPage, totalPages, onPageChange }) => (
  <div className="flex items-center border-accent border-2 rounded-4xl gap-4 p-2 bg-background">
    <button
      className={buttonClassName}
      onClick={() => onPageChange(currentPage - 1)}
      disabled={currentPage === 1}
    >
      <IconChevron width={24} height={24} direction={ChevronDirection.LEFT} />
    </button>
    {currentPage > 1 && (
      <button className={buttonClassName} onClick={() => onPageChange(1)}>
        1
      </button>
    )}
    {currentPage > 2 && <span className={ellipsisClassName}>...</span>}
    <span className="font-medium text-foreground">{currentPage}</span>
    {currentPage < totalPages - 1 && <span className={ellipsisClassName}>...</span>}
    {currentPage < totalPages && (
      <button className={buttonClassName} onClick={() => onPageChange(totalPages)}>
        {totalPages}
      </button>
    )}
    <button
      className={buttonClassName}
      onClick={() => onPageChange(currentPage + 1)}
      disabled={currentPage === totalPages}
    >
      <IconChevron width={24} height={24} direction={ChevronDirection.RIGHT} />
    </button>
  </div>
);

export default Pagination;
