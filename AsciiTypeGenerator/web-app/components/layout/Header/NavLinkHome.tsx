'use client';

import Link from 'next/link';
import { usePathname } from 'next/navigation';
import { type FC } from 'react';
import { pageUrls } from '@/shared/constants';

const NavLinkHome: FC = () => {
  const pathname = usePathname();
  const isActive = pathname === pageUrls.HOME;

  return (
    <Link
      className={`group font-heading text-2xl transition-colors ${
        isActive ? 'text-accent' : 'text-white hover:text-accent'
      }`}
      href={pageUrls.HOME}
      title="AsciiTypeGenerator Home"
    >
      {[...'ATG_'].map((char, index) => (
        <span
          key={index}
          className={
            index % 2 === 0
              ? isActive
                ? 'text-white'
                : 'text-accent group-hover:text-white'
              : isActive
                ? 'text-accent'
                : 'text-white group-hover:text-white'
          }
        >
          {char}
        </span>
      ))}
    </Link>
  );
};

export default NavLinkHome;
