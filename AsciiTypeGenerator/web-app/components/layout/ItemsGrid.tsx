import { FC, ReactNode } from 'react';

interface IProps {
  children: ReactNode;
  cols?: number;
}

const ItemsGrid: FC<IProps> = ({ children, cols = 3 }) => {
  const gridColsClass = `grid-cols-${cols}`;
  return <div className={`grid ${gridColsClass} gap-4`}>{children}</div>;
};

export default ItemsGrid;
