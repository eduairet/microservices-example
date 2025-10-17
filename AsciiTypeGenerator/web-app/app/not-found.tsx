import Link from 'next/link';
import Heading, { HeadingLevel } from '@/components/Heading';
import Paragraph from '@/components/Paragraph';
import { PAGE_URLS } from '@/shared/constants/pageUrls';

export default function NotFound() {
  return (
    <div className="flex flex-col gap-6 justify-center w-full h-full">
      <Heading level={HeadingLevel.H1}>Not Found</Heading>
      <Paragraph>Could not find requested resource</Paragraph>
      <Link
        className="text-accent hover:text-foreground underline transition-colors"
        href={PAGE_URLS.HOME}
      >
        Return Home
      </Link>
    </div>
  );
}
