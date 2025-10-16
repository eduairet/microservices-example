import { type FC, type ReactNode } from 'react';

interface IProps {
  children: ReactNode;
}

const MainContainer: FC<IProps> = ({ children }) => {
  return (
    <main className="flex flex-col gap-8 items-center w-full max-w-5xl px-10 pb-4 mx-auto">
      {children}
    </main>
  );
};

export default MainContainer;
