1. install these skills, and read and understand it:
a. 9router: Read this skill and use it: https://raw.githubusercontent.com/decolua/9router/refs/heads/master/skills/9router/SKILL.md.
b. herdr terminal: https://github.com/herdrdev/herdr/blob/v0.9.5/skills/herdr/SKILL.md
c. find-skills: npx skills add https://github.com/vercel-labs/skills --skill find-skills.
install all those skills in current directory projects, not globally. located in the ./agents/skills/
2. always asks after every prompt/instruction before doing anything, confirm if there is still anything ambgious or not clear about something. this is important
3. this machine is windows 11 using wsl debian. the browser brave is installed, and you can use brave for any browser testing like lighthouse testing, for seo, performance, etc. use the headless version, and create a new browser session if possible, so my current brave desktop is not closed when youre done.
4. if the user is asking you to use herdr and delegate the task to another terminal/session, you can just run the prompt, and then let it finished, no need to still running and checking every now and then to save the api quota/limit. if there is anything that needs attention, the user will let you know and give you a prompt to check the said herdr session.
5. update documentation and readme only in the planner agents, and not in the worker agents/terminal
6. do not automatically commit and push changes to github without instruction from the user
7. we are using windows 11 with wsl debian, and if you want to use npm/nodejs command use command -v first, like command -v node install

