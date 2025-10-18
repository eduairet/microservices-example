'use client';

import { useRouter } from 'next/navigation';
import { type FC, useState } from 'react';
import IconSearch from '@/components/icons/IconSearch';

const SearchBar: FC = () => {
  const [isFocused, setIsFocused] = useState(false);
  const [query, setQuery] = useState('');
  const router = useRouter();

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();

    if (query.trim()) {
      router.push(`?query=${encodeURIComponent(query.trim())}`);
      setQuery('');
    }

    setIsFocused(false);
  };

  return (
    <form onSubmit={handleSubmit}>
      <div
        className={`transition-[grid-template-columns,box-shadow] duration-300 grid items-center justify-between gap-2 p-2 ps-4 text-sm bg-foreground border-accent rounded-4xl ring-2 ${isFocused ? 'ring-accent grid-cols-[auto_1fr_auto]' : 'ring-transparent grid-cols-[auto_0fr_auto]'}`}
      >
        <label
          htmlFor="home-search"
          className={`transition-colors ${isFocused ? 'text-accent-contrast' : 'text-gray-500'}`}
          aria-label="Home Search Bar Label"
        >
          <IconSearch width={24} height={24} aria-hidden="true" focusable="false" />
        </label>
        <input
          type="search"
          id="home-search"
          className={`font-medium transition-colors delay-300 focus:ring-0 focus:outline-none bg-transparent w-full ${isFocused ? 'placeholder:text-gray-500 text-accent-contrast' : 'placeholder:text-transparent text-transparent'}`}
          name="home-search"
          placeholder="Search ASCII..."
          autoComplete="off"
          aria-labelledby="home-search-description"
          value={query}
          onChange={e => setQuery(e.target.value)}
          onFocus={() => setIsFocused(true)}
          onBlur={() => setIsFocused(false)}
        />
        <div id="home-search-description" className="sr-only">
          Search bar to find Alphabets, Artworks, and Creators
        </div>
        <button
          tabIndex={isFocused ? 0 : -1}
          type="submit"
          className="cursor-pointer transition-colors text-accent-contrast bg-accent hover:bg-accent-fade focus:ring-2 focus:outline-none focus:ring-accent-contrast font-medium rounded-4xl text-sm px-4 py-2 w-24"
        >
          Search
        </button>
      </div>
    </form>
  );
};

export default SearchBar;
