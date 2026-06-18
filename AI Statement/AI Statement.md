# AI Use Statement

**Project:** Subject 17 — 3D Horror Puzzle Escape Game  
**Developer:** Yuhang Chen  
**Last Updated:** 2026-05-26

---

## Overview

This document provides a transparent account of how AI tools were used during the development of *Subject 17*. All AI-assisted content was reviewed, critically evaluated, and significantly adapted before being incorporated into the final project.

---

## Tools Used

| Tool | Version / Platform | Primary Use |
|------|--------------------|-------------|
| Claude | Claude Sonnet 4.6, web | Game concept brainstorming and refinement |

---

## What I Used AI For

- **Game Concept Brainstorming & Refinement:** Used Claude to explore and expand on a small number of initial game concept ideas — specifically to brainstorm horror atmosphere mechanics and get feedback on early design directions. This constituted a minor portion of the overall concept development process.

---

## How I Adjusted and Evaluated AI Output

AI outputs were never used directly without review. My adjustment process typically involved:

1. **Evaluating relevance** — Checking whether the AI's suggestions genuinely matched the tone and scope of *Subject 17*, which targets an adult horror puzzle audience within a strict 4.5-week development window.
2. **Filtering against my own vision** — The majority of AI-generated ideas were discarded or substantially modified to fit my established design direction. Only a small number of suggestions contributed to the final concept.
3. **Anchoring to my original design** — Core ideas such as puzzle-triggered danger escalation, the vulnerability-focused no-combat design, and the narrative arc of "Subject 17" were conceived independently and remained unchanged by AI input.
4. **Combining selectively** — Where AI suggestions were useful, they served as a sounding board that helped me articulate or confirm ideas I already had, rather than generating new design directions.

---

## Typical AI Interaction Examples

*The following screenshots show representative examples of how I prompted and refined AI outputs during development.*

---

### Example 1 — Horror Atmosphere Mechanic Brainstorming

**What I asked / Why:**

I wanted to explore whether my initial idea of escalating danger in response to puzzle completion was a sufficiently original mechanic. I asked Claude to brainstorm horror game atmosphere mechanics to see if anything similar already existed and to help me articulate what made my idea distinctive.

**What I changed after:**

Claude's suggestions largely confirmed that puzzle-triggered danger escalation (adding more monsters, expanding patrol range, intensifying lighting and audio) was an original angle. However, the specific implementation — tying escalation to fuse puzzle completion across three distinct zones — was entirely my own design. I discarded Claude's more generic suggestions (e.g., time-based escalation) in favour of my own spatially-gated progression system.

---

## My Own Contributions

The following elements of the project were conceived and created entirely by me, without AI assistance:

- The full narrative concept: a man waking up in a basement with amnesia, discovering he is "Subject 17," and piecing together the truth through environmental storytelling
- The core loop design: Explore → Discover Clues → Collect Items/Codes → Solve Puzzles → Evade Monster → Unlock New Areas → Escape
- The puzzle-triggered danger escalation mechanic (lighting, soundscape, monster count, and patrol range all intensifying as the player progresses)
- The three-puzzle vertical slice structure (fuse puzzle, password door puzzle, sound lure puzzle) and the full level layout (starting room, main corridor, power control room, archive room, exit area)
- The no-combat, vulnerability-focused design philosophy and its connection to the *Outlast* / *Amnesia* reference games
- The monster FSM design (Patrol → Chase → Return) and all associated detection and audio feedback logic
- All Unity C# system architecture and script planning (PlayerController, EnemyFSM, GameStateManager, etc.)
- The full 4.5-week development schedule, milestone plan, and MoSCoW feature prioritisation
- All legal, ethical, social, accessibility, and security documentation
- The iterative design history: moving from Cube Rush → VETO → Subject 17, from first-person to third-person perspective, and from a large map to a focused, completable vertical slice

---

## Reflection

Using Claude for a small amount of early-stage brainstorming helped me articulate and stress-test ideas I already had, but it played a minimal role in the final design of *Subject 17*. The most meaningful aspects of the game — the escalating danger system, the narrative premise, the puzzle structure, and the overall player experience — were developed through my own design thinking and iterative revision over the course of the project. AI was most useful as a way to quickly survey a broad idea space, which I then narrowed down based on my own creative judgment and the constraints of a 4.5-week timeline. The core lesson I took away is that AI works best as a reflective tool rather than a generative one: it helped me see my own ideas more clearly, not replace them.

---

*AI was used as a tool to support my creative and technical process. All final decisions, implementations, and original ideas remain my own work.*
