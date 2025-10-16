import Heading, { HeadingLevel } from '@/components/Heading';
import Paragraph from '@/components/Paragraph';

export default function Home() {
  return (
    <div className="flex flex-col gap-6 justify-center w-full h-full">
      <Heading
        level={HeadingLevel.H1}
        className="flex flex-col gap-2 justify-center"
      >
        <span>Ascii</span>
        <span className="text-foreground">Type</span>
        <span>Generator</span>
      </Heading>
      <Paragraph>
        Generate ASCII art from text using different fonts created by the
        community.
      </Paragraph>
    </div>
  );
}
