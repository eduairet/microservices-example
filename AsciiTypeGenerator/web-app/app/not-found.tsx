import Link from 'next/link';
import Heading, { HeadingLevel } from '@/components/text/Heading';
import Paragraph from '@/components/text/Paragraph';
import { pageUrls } from '@/shared/constants';

export default function NotFound() {
  return (
    <div className="flex flex-col gap-6 justify-center w-full h-full">
      <Heading level={HeadingLevel.H1}>Not Found</Heading>
      <Paragraph>Could not find requested resource</Paragraph>
      <Link
        className="text-accent hover:text-foreground underline transition-colors"
        href={pageUrls.HOME}
      >
        Return Home
      </Link>
    </div>
  );
}
