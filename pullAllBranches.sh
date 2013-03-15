#!/bin/bash
for branch in `git branch -a | grep remotes | grep -v HEAD | grep -v master`; do
    if git branch | grep -Gq "^[\* ] ${branch##*/}$"
	then
		git clean -f -d
		git reset --hard HEAD
		git clean -f -d
	    git checkout ${branch##*/}

		git clean -f -d
		git reset --hard HEAD
		git clean -f -d
		git pull
		sleep 1
	else
	    git branch --track ${branch##*/} $branch
	fi
done