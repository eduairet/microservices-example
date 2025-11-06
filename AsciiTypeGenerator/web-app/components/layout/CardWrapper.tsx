import { FC, ReactNode } from 'react';

const CardWrapper: FC<{ children: ReactNode }> = ({ children }) => {
  return <div className="p-4 rounded-lg shadow-md bg-cyan-950">{children}</div>;
};

export default CardWrapper;
