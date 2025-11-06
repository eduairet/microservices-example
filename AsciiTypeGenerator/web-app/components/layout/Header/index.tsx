import { type FC } from 'react';
import NavLinkHome from '@/components/layout/Header/NavLinkHome';
import SearchBar from '@/components/layout/Header/SearchBar';

const Header: FC = () => (
  <header className="p-10 flex gap-2 flex-wrap items-center w-full justify-between sticky top-0 bg-background z-10 flex-col md:flex-row">
    <NavLinkHome />
    <SearchBar />
  </header>
);

export default Header;
