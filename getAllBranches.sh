#!/bin/bash
for branch in `git branch -a | grep remotes | grep -v HEAD | grep -v master`; do
    if ! git branch | grep -Gq "^[\* ] ${branch##*/}$"
	then
	    git branch --track ${branch##*/} $branch
	fi
done