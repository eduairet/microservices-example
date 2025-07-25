# Development Notes

- When we're dockerizing a microservice project, we need to avoid HTTPS in the `projectLaunchSettings.json` file. This is because Docker containers typically do not handle HTTPS directly, and it can complicate the setup unnecessarily. Instead, we should focus on HTTP for local development within Docker.