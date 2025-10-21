'use client';

import Link from 'next/link';
import { usePathname } from 'next/navigation';
import { type FC } from 'react';
import { pageUrls } from '@/shared/constants/pageUrls';

const NavLinkHome: FC = () => {
  const pathname = usePathname();
  const isActive = pathname === pageUrls.HOME;

  return (
    <Link
      className={`group font-heading transition-colors ${
        isActive ? 'text-accent' : 'text-white hover:text-accent'
      }`}
      href={pageUrls.HOME}
    >
      Ascii
      <span
        className={`transition-colors ${
          isActive ? 'text-white' : 'text-accent group-hover:text-white'
        }`}
      >
        Type
      </span>
      Generator
    </Link>
  );
};

export default NavLinkHome;
